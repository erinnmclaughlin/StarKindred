using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using StarKindred.API.Middleware;
using System.Text.Json.Serialization;

namespace StarKindred.API.Configuration;

public static class WebApiConfiguration
{
    public static void AddAndConfigureWebApi(this WebApplicationBuilder builder)
    {
        builder.AddAndConfigureMVC();
        builder.AddAndConfigureCors();
        builder.AddAndConfigureSwagger();

        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
    }

    private static void AddAndConfigureMVC(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(options =>
        {
            options.Filters.Add<InvalidModelStateFilter>();
            options.Filters.Add<AppExceptionFilter>();
            options.RespectBrowserAcceptHeader = true;
        })
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
    }

    private static void AddAndConfigureSwagger(this WebApplicationBuilder builder)
    {
        if (builder.Environment.IsProduction())
            return;

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Star Kindred API", Version = "v1" });
            c.CustomSchemaIds(type => type.FullName?.Replace("+", "."));
        });
    }

    private static void AddAndConfigureCors(this WebApplicationBuilder builder)
    {
        var config = builder.Configuration.GetSection("CORS");
        if (config.Exists() && config.GetSection("AllowedOrigins").Get<string[]>() is { Length: > 0 } allowedOrigins)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("StarKindred", policy =>
                {
                    policy
                        .WithOrigins(allowedOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                    ;
                });
            });
        }

    }
}
