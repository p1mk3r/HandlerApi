using HandlerApi.Settings;

var builder = WebApplication.CreateBuilder(args).ConfigureServices();
var app = builder.Build().ConfigureApp();

app.Run();