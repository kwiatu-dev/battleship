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
        Simulation game = new Simulation();
        game.SetBoardForPlayers();

        return Json(game);
    }
}