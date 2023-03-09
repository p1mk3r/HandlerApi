using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using HandlerApi.DTO;
using HandlerApi.Options;
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
        
        // Добавляем валидацию.
        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddFluentValidationClientsideAdapters();
        builder.Services.AddValidatorsFromAssemblyContaining<MessageValidator>();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        builder.Services.Configure<ReverseWordsOptions>(builder.Configuration.GetSection("Handlers:ReverseWordsOptions"));
        builder.Services.Configure<TwoDigitsSumOptions>(builder.Configuration.GetSection("Handlers:TwoDigitsSumOptions"));
        builder.Services.Configure<WordsCountOptions>(builder.Configuration.GetSection("Handlers:WordsCountOptions"));
        
        
        LoggingServices.DefaultBackend = new ConsoleLoggingBackend();

        return builder;
    }
}