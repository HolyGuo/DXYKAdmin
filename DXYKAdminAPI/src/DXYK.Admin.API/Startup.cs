//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using DXYK.Admin.Service;
using DXYK.Admin.API.Filters;
using Newtonsoft.Json.Serialization;

namespace DXYK.Admin.API
{
    public class Startup
    {
        ///<summary>
        ///服务名称
        ///</summary>
        const string SERVICE_NAME = "DXYK.Admin.API";

        ///<summary>
        ///Startup程序启动
        ///</summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        ///<summary>
        ///Configuration 应用配置
        ///</summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
                options.Filters.Add<GlobalValidateModelFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);
            RegisterRepository(services);
            RegisterService(services);
            RegisterSwagger(services);
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = SERVICE_NAME,
                    Version = "v1",
                    Description = "https://github.com/HolyGuo"
                });
                c.CustomSchemaIds((type) => type.FullName);
                var filePath = Path.Combine(AppContext.BaseDirectory, $"{SERVICE_NAME}.xml");
                if (File.Exists(filePath))
                {
                    c.IncludeXmlComments(filePath);
                }
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
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
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

