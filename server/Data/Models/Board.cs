namespace ndc.Data.Models;

public class Board{
    public int size { get; }
    public List<Ship> ships { get; }
    public List<List<string>> grid { get; }

    public Board(int size){
        this.size = size;
        this.ships = new List<Ship>();
        this.grid = new List<List<string>>();

        for (int y = 0; y < size; y++)
        {
            List<string> row = new List<string>();

            for (int x = 0; x < size; x++)
            {
                row.Add("");
            }

            this.grid.Add(row);
        }
    }

    public void Add(Ship ship){
        this.ships.Add(ship);

        for(int x = ship.bow.x; x <= ship.stern.x; x++){
            for(int y = ship.bow.y; y <= ship.stern.y; y++){
                this.grid[y][x] = ship.type;
            }
        }
    }
}

