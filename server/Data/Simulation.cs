
using ndc.Data.Models;

namespace ndc.Data;

public class Simulation: Game{
    public new Bot player1 { get; }
    public new Bot player2 { get; }
    public Simulation(){

    }

    public Simulation(Bot player1, Bot player2): base(player1, player2){
        this.player1 = player1;
        this.player2 = player2;
    }

    public void Init(){
        SetBoardForPlayers();
        StartGame();
    }

    private void SetBoardForPlayers(){
        this.player1.board = new Board(Game.boardSize);
        this.player2.board = new Board(Game.boardSize);

        foreach(KeyValuePair<string, int> kvp in Game.ships){
            string type = kvp.Key;
            int size = kvp.Value;
            Ship ship1 = Helpers.GenerateShipWithoutIntersection(player1, type, size);
            Ship ship2 = Helpers.GenerateShipWithoutIntersection(player2, type, size);
            player1.board.Add(ship1);
            player2.board.Add(ship2);
        }
    }

    private void StartGame(){
        while(player1.board.units > 0 && player2.board.units > 0){
            Point guess = new Point(-1, -1);
            bool hit = false, sunk = false;

            if(turn == player1){
                guess = player1.NextGuess();
                (hit, sunk) = Fire(guess, player1, player2);
            }
            else if(turn == player2){
                guess = player2.NextGuess();
                (hit, sunk) = Fire(guess, player2, player1);
            }

            history.Add(new {
                playerId = turn.id,
                shot = guess,
                hit,
                sunk
            });
        }
    }
}