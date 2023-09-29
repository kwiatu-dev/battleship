
using ndc.Data.Models;

namespace ndc.Data;

public class Simulation: Game{
    public Simulation(){

    }

    public void SetBoardForPlayers(){
        player1.board = new Board(10);
        player2.board = new Board(10);

        foreach(KeyValuePair<string, int> kvp in Game.ships){
            string type = kvp.Key;
            int size = kvp.Value;
            Ship ship1 = Helpers.GenerateShipWithoutIntersection(player1, type, size);
            Ship ship2 = Helpers.GenerateShipWithoutIntersection(player2, type, size);

            player1.board.ships.Add(ship1);
            player2.board.ships.Add(ship2);
        }
    }
}