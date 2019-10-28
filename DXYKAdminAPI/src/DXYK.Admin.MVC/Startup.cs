using DXYK.Admin.Common.Cache;
using DXYK.Admin.MVC.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace DXYK.Admin.MVC
{
    public class Startup
    {
        ///<summary>
        ///服务名称
        ///</summary>
        const string SERVICE_NAME = "DXYK.Admin.MVC";

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                //关闭GDPR规范
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc(option =>
            {
                option.Filters.Add<AuthFilter>();
                option.Filters.Add<GlobalExceptionFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            #region 缓存配置
            services.AddMemoryCache();
            services.AddSingleton<ICacheService, MemoryCacheService>();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies", o =>
            {
                o.LoginPath = new PathString("/Login");
            })
            .AddCookie("AppId", o =>
             {
                 o.LoginPath = new PathString("/Login");
             });
            //RedisHelper.Initialization(new CSRedis.CSRedisClient(Configuration["Cache:Configuration"]));
            #endregion
            RegisterRepository(services);
            RegisterService(services);
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                //options.SerializerSettings.Converters.Add(new Utils.JsonLongConverter());
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //跨域
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvcWithDefaultRoute();
        }
    }
}
