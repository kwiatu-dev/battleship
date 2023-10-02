namespace ndc.Data.Models;

public class Point{
    public int x { get; set; }
    public int y { get; set; }
    
    public Point(int x, int y){
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object obj){
        if (obj == null || GetType() != obj.GetType()){
            return false;
        }

        Point otherPoint = (Point)obj;
        return this.x == otherPoint.x && this.y == otherPoint.y;
    }

    public override int GetHashCode(){
        return Tuple.Create(x, y).GetHashCode();
    }
}