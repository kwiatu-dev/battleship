using ndc.Data;

namespace ndc.Data.Models;

public class Actions{
    public (bool, bool) Fire(Point p, Player player, Player oponent){
        bool hit = false;
        bool sunk = false;

        if(player.shots[p.y][p.x] == true){
            throw new ArgumentException("This location has already been shot at");
        }

        foreach (Ship ship in oponent.board.ships){
            if(Helpers.IsPointOnSegment(ship.bow, ship.stern, p)){
                ship.hp--;
                oponent.board.units--;
                hit = true;
                player.sinkings[p.y][p.x] = true;

                if(ship.hp == 0){
                    sunk = true;

                    for(int y = ship.bow.y; y <= ship.stern.y; y++){
                        for(int x = ship.bow.x; x <= ship.stern.x; x++){
                            player.destroyed[y][x] = true;
                        }
                    }
                } 

                if(ship.hp < 0){
                    throw new ArgumentException("Health points cannot be less than 0");
                }

                if(oponent.board.units < 0){
                    throw new ArgumentException("Units cannot be less then 0");
                }

                break;
            }
        }

        player.shots[p.y][p.x] = true;

        return (hit, sunk);
    }

    public void PlaceShipOnTheBoard(Ship ship, Board board){
        board.ships.Add(ship);
        board.units += ship.size;

        for(int x = ship.bow.x; x <= ship.stern.x; x++){
            for(int y = ship.bow.y; y <= ship.stern.y; y++){
                board.grid[y][x] = ship.type;
            }
        }
    }
}