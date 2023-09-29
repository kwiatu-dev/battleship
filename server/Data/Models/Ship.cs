using Microsoft.AspNetCore.Razor.Language.CodeGeneration;

namespace ndc.Data.Models;

public class Ship{
    public int size { get; }
    public string type { get; }
    public int hp { get; set; }
    public Point bow { get; }
    public Point stern { get; }
    public List<Point> hits { get; }

    public Ship(string type, int size, Point bow, Point stern){
        this.type = type;
        this.bow = bow;
        this.stern = stern;
        this.size = size;
        this.hp = size;
        this.hits = new List<Point>();
    }
}