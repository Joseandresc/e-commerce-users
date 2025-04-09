using eCommerce.Infraestructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
//Add infraestructure services
builder.Services.AddInfrastructure();
//Add core services
builder.Services.AddCore();
//Add cors services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", builder =>
    {
        builder
            .WithOrigins("http://localhost:4200") // 👈 must be exact
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

//Add authorization services
builder.Services.AddAuthorization();
//Add controller
builder.Services.AddControllers().AddJsonOptions(options =>
{ options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
//Add automappers
builder.Services.AddAutoMapper(
    typeof(ApplicationUserMappingProfile).Assembly,
    typeof(RegisterRequestMappingProfile).Assembly);
builder.Services.AddFluentValidationAutoValidation();
//Add services used by Swagger
builder.Services.AddEndpointsApiExplorer();
//Add swagger generation services
builder.Services.AddSwaggerGen();
var app = builder.Build();
//Fluent validations


app.MapGet("/", () => "Hello World!");

app.UseExceptionHandlingMiddleware();
//Routing
app.UseRouting();
//Swagger
app.UseSwagger();
//Swagger UI
app.UseSwaggerUI();
//CORS
app.UseCors("AllowFrontend"); // ✅ must be here and with policy name
//Authentication
app.UseAuthentication();      // ✅ auth first
//Authorization
app.UseAuthorization();       // ✅ then authorization
//Endpoints
app.MapControllers();
app.Run();
