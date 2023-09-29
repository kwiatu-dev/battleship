namespace ndc.Data.Models;

public class Board{
    public int size { get; }
    public List<Ship> ships { get; }

    public Board(int size){
        this.size = size;
        this.ships = new List<Ship>();
    }
}

