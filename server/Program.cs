using ndc.Controllers;
using ndc.Data;
using ndc.Data.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
 
var app = builder.Build();
app.UseStaticFiles();
app.MapFallbackToFile("index.html");

//var libPath = Path.Combine(app.Environment.WebRootPath, "Content");
//var contentLibrary = new ContentLibrary(libPath).Load();
// var path = Path.Combine(app.Environment.WebRootPath, "BattleShip", "data.json");
//var battleShipData = new BattleShipData(path);
// battleShipData.load();
var controller = new BattleShipController();

app.UseCors(builder => builder
 .AllowAnyOrigin()
 .AllowAnyMethod()
 .AllowAnyHeader()
);

//load the routes
//ndc.Api.Content.MapRoutes(app, contentLibrary);
ndc.Api.BattleShipApi.MapRoutes(app, controller);

app.Run();

//this is for tests
public partial class Program { }