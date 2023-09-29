using ndc.Data;

namespace ndc.Data.Models;

public class Actions{
    public void Fire(Point p, Player player){
        foreach (Ship ship in player.board.ships){
            if(Helpers.IsCollinear(ship.bow, ship.stern, p)){
                ship.hp--;
            }
        }
    }
}