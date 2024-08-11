using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation;
using StarKindred.API.Configuration;
using StarKindred.API.Services;
using StarKindred.Common.Services;
using StarKindred.AzureMailer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddAndConfigureWebApi();
builder.AddAndConfigureStripe();
builder.AddAndConfigureDatabase();

if (builder.Configuration.GetSection("DiscordLogger").Exists())
{
    builder.AddDiscordLogging();
}

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly, lifetime: ServiceLifetime.Singleton);

builder.Services
    .AddSingleton(_ => Random.Shared)
    .AddSingleton<IPassphraseHasher, PassphraseHasher>()
    .AddScoped<ICurrentUser, CurrentUser>()
    .AddSingleton<IStarKindredMailer, AzureMailer>()
    .AddSingleton<IAddressHelper, AddressHelper>()
    .AddHttpContextAccessor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseCors("StarKindred");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseHeartbeatHandler("/heartbeat");

var jsonSerializationOptions = new JsonSerializerOptions()
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    Converters = { new JsonStringEnumConverter() }
};

app.UseBadRequestHandler(jsonSerializationOptions);

app.Run();

// ReSharper disable once PartialTypeWithSinglePart
public partial class Program { } // for tests & benchmarking