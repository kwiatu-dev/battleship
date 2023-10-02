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

    public void Add(Ship ship){
        this.ships.Add(ship);
        this.units += ship.size;

        for(int x = ship.bow.x; x <= ship.stern.x; x++){
            for(int y = ship.bow.y; y <= ship.stern.y; y++){
                this.grid[y][x] = ship.type;
            }
        }
    }
}

