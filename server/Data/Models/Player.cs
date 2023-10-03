namespace ndc.Data.Models;

public class Player{
    public string id { get; }
    public Board board { get; }
    public List<List<bool>> shots { get; }
    public List<List<bool>> sinkings { get; }

    public Player(string id){
        this.id = id;
        this.board = new Board(Game.boardSize);
        this.shots = Helpers.Initialize2DListWithValues(Game.boardSize, false);
        this.sinkings = Helpers.Initialize2DListWithValues(Game.boardSize, false);
    }
}