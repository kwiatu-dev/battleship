namespace ndc.Data.Models;

public class Player{
    public string id { get; }
    public Board board { get; set; }
    public List<List<bool>> shots { get; }

    public Player(string id){
        this.id = id;
        this.shots = Helpers.Initialize2DListWithValues(Game.boardSize, false);
    }
}