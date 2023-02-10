using Azure.Identity;
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
        builder.Services.ConfigureVipps(builder.Configuration, "Vipps");

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
