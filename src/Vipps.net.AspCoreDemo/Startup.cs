using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Vipps.net.Infrastructure;

namespace Vipps.net.AspCoreDemo
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
            var vippsConfigurationOptions = new VippsConfigurationOptions
            {
                ClientId = Configuration.GetValue<string>("CLIENT-ID")!,
                ClientSecret = Configuration.GetValue<string>("CLIENT-SECRET")!,
                MerchantSerialNumber = Configuration.GetValue<string>("MERCHANT-SERIAL-NUMBER")!,
                SubscriptionKey = Configuration.GetValue<string>("SUBSCRIPTION-KEY")!,
                UseTestMode = true,
                PluginName = Assembly.GetExecutingAssembly().GetName().Name,
                PluginVersion =
                    Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0",
            };

            services.AddTransient(_ => vippsConfigurationOptions);
            services.AddTransient<IVippsApi, VippsApi>(
                (sp) =>
                    new VippsApi(vippsConfigurationOptions, null, sp.GetService<ILoggerFactory>())
            );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo { Title = "Vipps .Net SDK ASP Core demo", Version = "v1" }
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(
                        "/swagger/v1/swagger.json",
                        "Vipps .Net SDK ASP Core demo v1"
                    );
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
