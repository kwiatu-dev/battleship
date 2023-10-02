using ndc.Data;

namespace ndc.Data.Models;

public class Actions{
    public (bool, bool) Fire(Point p, Player player, Player oponent){
        bool hit = false;
        bool sunk = false;

        foreach (Ship ship in oponent.board.ships){
            if(Helpers.IsCollinear(ship.bow, ship.stern, p) && !ship.hits.Contains(p)){
                ship.hp--;
                oponent.board.units--;
                ship.hits.Add(p);
                hit = true;
                if(ship.hp == 0) sunk = true;
            }
        }

        player.shots[p.y][p.x] = true;

        return (hit, sunk);
    }
}