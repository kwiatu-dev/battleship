namespace ndc.Data.Models;

public class Board{
    public int units { get; set; }
    public int size { get; }
    public List<Ship> ships { get; }
    public List<List<string>> grid { get; }

    public Board(int size){
        this.units = 0;
        this.size = size;
        this.ships = new List<Ship>();
        this.grid = Helpers.Initialize2DListWithValues(Game.boardSize, "");
    }
}

