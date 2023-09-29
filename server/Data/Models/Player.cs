namespace ndc.Data.Models;

public class Player{
    public string id { get; }
    public Board board { get; set; }
    public List<Point> history { get; }

    public Player(string id){
        this.id = id;
        this.history = new List<Point>();
    }
}