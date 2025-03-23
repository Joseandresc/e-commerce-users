using eCommerce.Infraestructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//Add infraestructure services
builder.Services.AddInfrastructure();
//Add core services
builder.Services.AddCore();
app.MapGet("/", () => "Hello World!");

app.UseExceptionHandlingMiddleware();
//Routing
app.UseRouting();
//Authorization
app.UseAuthorization();
//Authentication
app.UseAuthentication();
//Endpoints
app.MapControllers();
app.Run();
