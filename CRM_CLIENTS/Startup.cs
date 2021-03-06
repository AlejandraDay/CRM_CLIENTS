using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CDM_CLIENTS.BusinessLogic;
using CDM_CLIENTS.Database;
using CRM_CLIENTS.Middlewares;

using Serilog;
using Serilog.Events;

namespace CDM_CLIENTS
{
    public class Startup
    {
        const string SWAGGER_SECTION_SETTING_KEY = "SwaggerSettings";
        const string SWAGGER_SECTION_SETTING_TITLE_KEY = "Title";
        const string SWAGGER_SECTION_SETTING_VERSION_KEY = "Version";
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();

            string logpath = Configuration.GetSection("Logging").GetSection("FileLocation").Value;

             Log.Logger  = new  LoggerConfiguration()
                .MinimumLevel
                .Error()
                .WriteTo.Console()
                .WriteTo.RollingFile(logpath, LogEventLevel.Error)
                .CreateLogger() ;

            Log.Logger = new LoggerConfiguration()
            //Instances 
                .MinimumLevel 
                .Information()
                .WriteTo.Console()
                .WriteTo.RollingFile(logpath, LogEventLevel.Information)
                .CreateLogger();
                            
            Log.Information("- The App is using the CONFIGURATION FILE  :  " + $"appsettings.{env.EnvironmentName}.json");       
         }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IClientLogic, ClientLogic>();
            services.AddSingleton<IClientTableDB, ClientTableDB>();

            services.AddTransient<IRankingLogic, RankingLogic>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.WithOrigins("*")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod()
                                      );
            });

            var swaggerTitle = Configuration
                .GetSection(SWAGGER_SECTION_SETTING_KEY)
                .GetSection(SWAGGER_SECTION_SETTING_TITLE_KEY);
            var swaggerVersion = Configuration
                .GetSection(SWAGGER_SECTION_SETTING_KEY)
                .GetSection(SWAGGER_SECTION_SETTING_VERSION_KEY);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc
                (
                    swaggerVersion.Value,
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = swaggerTitle.Value,
                        Version = swaggerVersion.Value
                    }
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Middlewares
            app.UseMiddleware(typeof(ExceptionMiddleware));

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clients CRUD");
            });

            
        }
    }
}
