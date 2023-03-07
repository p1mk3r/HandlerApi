namespace HandlerApi.Settings;

public static class AppHelper
{
    public static WebApplication ConfigureApp(this WebApplication app)
    {
        // Configure the HTTP request pipeline.      
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}