using ndc.Controllers;
using ndc.Data;
using ndc.Data.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
 
var app = builder.Build();
app.UseStaticFiles();
app.MapFallbackToFile("index.html");

var controller = new BattleShipController();

app.UseCors(builder => builder
 .AllowAnyOrigin()
 .AllowAnyMethod()
 .AllowAnyHeader()
);

ndc.Api.BattleShipApi.MapRoutes(app, controller);

app.Run();

public partial class Program { }