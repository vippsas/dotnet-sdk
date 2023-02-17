using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Vipps.Infrastructure;
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
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            var vippsConfigurationOptions = new VippsConfigurationOptions
            {
                ClientId = configuration.GetValue<string>("CLIENT-ID")!,
                ClientSecret = configuration.GetValue<string>("CLIENT-SECRET")!,
                MerchantSerialNumber = configuration.GetValue<string>("MERCHANT-SERIAL-NUMBER")!,
                SubscriptionKey = configuration.GetValue<string>("SUBSCRIPTION-KEY")!,
                UseTestMode = true,
                PluginName = Assembly.GetExecutingAssembly().GetName().Name,
                PluginVersion =
                    Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0"
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
