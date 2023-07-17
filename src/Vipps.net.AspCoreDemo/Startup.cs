﻿using System;
using dotenv.net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            DotEnv.Load();
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

            var vippsApi = VippsApi.Create(vippsConfigurationOptions);

            services.AddSingleton(vippsApi.CheckoutService());
            services.AddSingleton(vippsApi.EpaymentService());
            services.AddSingleton(vippsApi.LoginService());

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
