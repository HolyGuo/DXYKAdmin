//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using DXYK.Admin.API.Filters;
using DXYK.Admin.Common.Authorize;
using DXYK.Admin.Common.Cache;
using DXYK.Admin.Extensions.JWT.Config;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DXYK.Admin.API
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        ///<summary>
        ///服务名称
        ///</summary>
        const string SERVICE_NAME = "DXYK.Admin.API";

        ///<summary>
        ///Configuration 应用配置
        ///</summary>
        public IConfiguration Configuration { get; }

        ///<summary>
        ///Startup程序启动
        ///</summary>
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            this.Configuration = builder.Build();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromMinutes(15);
            //    options.Cookie.HttpOnly = true;
            //});
            services.AddMvc(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
                options.Filters.Add<GlobalValidateModelFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);
            #region
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
             {
                 options.LoginPath = new PathString("/index.html");
             })
             .AddJwtBearer(JwtAuthorizeAttribute.JwtAuthenticationScheme, options =>
             {
                 var jwtConfig = new JwtAuthConfigModel();
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,//是否验证Issuer
                     ValidateAudience = true,//是否验证Audience
                     ValidateIssuerSigningKey = true,//是否验证SecurityKey
                     ValidateLifetime = true,//是否验证超时  当设置exp和nbf时有效 同时启用ClockSkew 
                     ClockSkew = TimeSpan.FromSeconds(30),//注意这是缓冲过期时间，总的有效时间等于这个时间加上jwt的过期时间，如果不配置，默认是5分钟
                     ValidAudience = jwtConfig.Audience,//Audience
                     ValidIssuer = jwtConfig.Issuer,//Issuer，这两项和前面签发jwt的设置一致
                     RequireExpirationTime = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtAuth:SecurityKey"]))//拿到SecurityKey
                 };
                 options.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         // 如果过期，则把<是否过期>添加到，返回头信息中
                         if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                         {
                             context.Response.Headers.Add("Token-Expired", "true");
                         }
                         return Task.CompletedTask;
                     }
                 };
             });

            #endregion

            #region  授权
            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy => policy.RequireRole("App").Build());
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                options.AddPolicy("AdminOrUser", policy => policy.RequireRole("Admin,User").Build());
            });
            #endregion

            #region 缓存配置
            services.AddMemoryCache();
            services.AddSingleton<ICacheService, MemoryCacheService>();
            //RedisHelper.Initialization(new CSRedis.CSRedisClient(Configuration["Cache:Configuration"]));
            #endregion

            RegisterRepository(services);
            RegisterService(services);
            RegisterSwagger(services);
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                options.SerializerSettings.Converters.Add(new Utils.JsonLongConverter());
            });
            services.AddCors();


        }

        ///<summary>
        ///Repository仓储注册
        ///</summary>
        private void RegisterRepository(IServiceCollection services)
        {
            services.AddSmartSql()
            .AddRepositoryFromAssembly(options =>
            {
                options.AssemblyString = "DXYK.Admin.Repository";
            });
        }

        ///<summary>
        ///Service服务注册
        ///</summary>
        private void RegisterService(IServiceCollection services)
        {
            var assembly = Assembly.Load("DXYK.Admin.Service");
            var allTypes = assembly.GetTypes();
            foreach (var type in allTypes)
            {
                services.AddSingleton(type);
            }
        }

        ///<summary>
        ///Swagger注册
        ///</summary>
        private void RegisterSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = SERVICE_NAME,
                    Version = "v1",
                    Description = "https://github.com/HolyGuo"
                });
                options.CustomSchemaIds((type) => type.FullName);
                var filePath = Path.Combine(AppContext.BaseDirectory, $"{SERVICE_NAME}.xml");
                if (File.Exists(filePath))
                {
                    options.IncludeXmlComments(filePath);
                }
                //添加header验证信息
                //options.OperationFilter<SwaggerHeader>();
                var security = new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } }, };
                //添加一个必须的全局安全信息，和AddSecurityDefinition方法指定的方案名称要一致，这里是Bearer。
                options.AddSecurityRequirement(security);
                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 参数结构: \"Authorization: Bearer {token}\"",
                    //jwt默认的参数名称
                    Name = "Authorization",
                    //jwt默认存放Authorization信息的位置(请求头中)
                    In = "header",
                    Type = "apiKey"
                });
            });
        }

        ///<summary>
        ///Configure配置
        ///</summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //跨域
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            //app.UseSession();
            app.UseMvc();
            ConfigureSwagger(app);
        }

        ///<summary>
        ///Swagger配置
        ///</summary>
        private void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {

            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", SERVICE_NAME);
            });

        }
    }

}


