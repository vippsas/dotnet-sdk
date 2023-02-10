using Azure.Identity;
using Vipps.Infrastructure;
using Vipps.net.Demo.Controllers;
using Vipps.net.Infrastructure;

internal sealed class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var host = builder.Configuration.GetValue<string>("keyvaultHost");
        builder.Configuration.AddAzureKeyVault(
            new Uri($"https://{host}.vault.azure.net/"),
            new DefaultAzureCredential()
        );

        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<CheckoutController>().AddHttpClient();

        // This line configures vipps from a configuration section named "Vipps"
        //builder.Services.ConfigureVipps(builder.Configuration, "Vipps");

        // This line configures vipps with custom settings
        var vippsConfigurationOptions = new VippsConfigurationOptions
        {
            ClientId = builder.Configuration.GetValue<string>("CLIENT-ID")!,
            ClientSecret = builder.Configuration.GetValue<string>("CLIENT-SECRET")!,
            MerchantSerialNumber = builder.Configuration.GetValue<string>(
                "MERCHANT-SERIAL-NUMBER"
            )!,
            SubscriptionKey = builder.Configuration.GetValue<string>("SUBSCRIPTION-KEY")!,
            UseTestMode = true
        };
        builder.Services.ConfigureVipps(vippsConfigurationOptions);

        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
