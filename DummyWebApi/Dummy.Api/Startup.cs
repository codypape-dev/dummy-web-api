using Dummy.Business;
using Dummy.Mapping;
using Dummy.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace Dummy.Api
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AppVariables.SetEnviroment(Configuration);
            // Add Cors
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddMvcCore()
                .AddApiExplorer()
                .AddJsonFormatters()
               .AddJsonOptions(options =>
               {
                   //Change Properties Names to Camel Case 
                   options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
               })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMappings();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Dummies", Version = "v1" });
                var xmlPath = Path.Combine(AppContext.BaseDirectory, AppVariables.DocumentationXML);
                c.IncludeXmlComments(xmlPath);

            });

            services.AddBusinessComponents();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHsts();

            // Enable Cors
            app.UseCors(builder =>
             builder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dummies");
            });

        }
    }
}
