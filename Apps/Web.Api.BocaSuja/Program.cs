using Core.BocaSuja;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/health", () => "OK");
app.MapGet("/app/health", () => Health.CHECK);

app.Run();
