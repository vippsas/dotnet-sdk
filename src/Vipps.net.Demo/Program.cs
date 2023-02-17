using System.Reflection;
using Azure.Identity;
using Vipps.Infrastructure;
using Vipps.net.Demo.Controllers;
using Vipps.net.Infrastructure;

internal sealed class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // The following line fetches the name of the key vault to be used for fetching secretes.
        var host = builder.Configuration.GetValue<string>("keyvaultHost");
        // The following lines adds secrets from the key vault to the configuration.
        builder.Configuration.AddAzureKeyVault(
            new Uri($"https://{host}.vault.azure.net/"),
            new DefaultAzureCredential()
        );

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // The following line sets up dependency injection of an http Client to be used for CheckoutController.
        builder.Services.AddScoped<CheckoutController>().AddHttpClient();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // The following (commented out) line configures vipps from a configuration section named "Vipps".
        //builder.Services.ConfigureVipps(builder.Configuration, "Vipps");

        // The following lines initialises VippConfigurationOptions with values fetched from key vault.
        var vippsConfigurationOptions = new VippsConfigurationOptions
        {
            ClientId = builder.Configuration.GetValue<string>("CLIENT-ID")!,
            ClientSecret = builder.Configuration.GetValue<string>("CLIENT-SECRET")!,
            MerchantSerialNumber = builder.Configuration.GetValue<string>(
                "MERCHANT-SERIAL-NUMBER"
            )!,
            SubscriptionKey = builder.Configuration.GetValue<string>("SUBSCRIPTION-KEY")!,
            UseTestMode = true,
            PluginName = Assembly.GetExecutingAssembly().GetName().Name,
            PluginVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0"
        };

        // The following line configures vipps with custom settings
        VippsConfiguration.ConfigureVipps(
            vippsConfigurationOptions,
            app.Services.GetService<ILoggerFactory>()
        );

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
