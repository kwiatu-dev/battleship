using ndc.Data;
using ndc.Controllers;

namespace ndc.Api;

public static class BattleShipApi{

  public static void MapRoutes(IEndpointRouteBuilder app, BattleShipController controller)
  {
    app.MapGet("api/battleship/", () => controller.Index());
  }
  
}