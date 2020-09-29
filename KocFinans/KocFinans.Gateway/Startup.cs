using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KocFinans.Public.MicroServices.Credits;
using KocFinans.Public.MicroServices.CreditScore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using WebApiContrib.Core.Formatter.Protobuf;

namespace KocFinans.Gateway
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("RabbitMq");
            services.AddCors();
            services.AddControllers()
                .AddProtobufFormatters();
            services.AddSingleton<ICreditScoreMicroservice>
                (serviceProvider => new CreditScoreMicroService());
            services.AddSingleton<ICreditsMicroService>
               (serviceProvider => new CreditsMicroService());
            services.AddSingleton(serviceProvider =>
            {
                var uri = new Uri(connection);
                return new ConnectionFactory
                {
                    Uri = uri,
                };
            });
           
            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()

            );

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
