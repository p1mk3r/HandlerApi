using FluentValidation;
using HandlerApi.DTO;
using HandlerApi.Validators;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Console;

namespace HandlerApi.Settings;

public static class ServicesHelper
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddControllers();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IValidator<Message>, MessageValidator>();

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        LoggingServices.DefaultBackend = new ConsoleLoggingBackend();

        return builder;
    }
}