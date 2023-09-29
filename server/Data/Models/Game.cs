namespace ndc.Data.Models;

public class Game: Actions{
    public static Dictionary<string, int> ships = new Dictionary<string, int>
    {
        {"Carrier", 5},
        {"Battleship", 4},
        {"Destroyer", 3},
        {"Submarine", 3},
        {"Patrol Boat", 2},
    };

    public static int boardSize = 10; 
    public Player player1 { get; }
    public Player player2 { get; }

    public Player turn { get; set; }

    public Game(){
        this.player1 = new Player("player-1");
        this.player2 = new Player("player-2");
        this.turn = Helpers.random.Next(2) == 1 ? player1 : player2;
    }

    public Game(Player player1, Player player2){
        this.player1 = player1;
        this.player2 = player2;
        this.turn = Helpers.random.Next(2) == 1 ? player1 : player2;
    }
}