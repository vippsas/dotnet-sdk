using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Vipps.net.Infrastructure;

namespace Vipps.net.AspCore31Demo
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IConfiguration configuration
        )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(); 
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name v1");
                });
            }
            
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            var vippsConfigurationOptions = new VippsConfigurationOptions
            {
                PluginName = "Sommerprosjekt plugin",
                PluginVersion = "1.0.0",
                ClientId = Environment.GetEnvironmentVariable("CLIENT_ID"),
                ClientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET"),
                MerchantSerialNumber = Environment.GetEnvironmentVariable("MSN"),
                SubscriptionKey = Environment.GetEnvironmentVariable("OCP_APIM_SUBSCRIPTION_KEY"),
                UseTestMode = true
            };

            // The following line configures vipps with custom settings
            VippsConfiguration.ConfigureVipps(
                vippsConfigurationOptions,
                app.ApplicationServices.GetService<ILoggerFactory>()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
