using ndc.Data.Models;
using Microsoft.AspNetCore.Mvc;
using ndc.Data;

namespace ndc.Controllers;

public class BattleShipController: Controller
{
    public BattleShipController(){

    }

    public IActionResult Index()
    {
        Bot player1 = new Bot("player-1");
        Bot player2 = new Bot("player-2");
        Simulation game = new Simulation(player1, player2);

        return Json(game);
    }
}