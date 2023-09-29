using ndc.Data.Models;

namespace ndc.Data;

public class Helpers{
    public static Random random = new Random();

    public static Ship GenerateShipWithoutIntersection(Player player, string type, int size){
        Ship ship;

        do{
            (Point bow, Point stern) = GenerateSegment(size);
            ship = new Ship(type, size, bow, stern);
        }
        while(IsShipIntersectingWithOthers(ship, player));

        return ship;
    }

    public static bool  IsShipIntersectingWithOthers(Ship newShip, Player player){
        foreach(Ship ship in player.board.ships){
            if(IsShipIntersecting(newShip, ship)){
                return true;
            }
        }

        return false;
    }

    public static bool IsShipIntersecting(Ship ship1, Ship ship2){
        int det1 = (int)Determinant3x3(ship1.bow, ship1.stern, ship2.bow);
        int det2 = (int)Determinant3x3(ship1.bow, ship1.stern, ship2.stern);
        int sign1 = Math.Sign(Determinant3x3(ship1.bow, ship1.stern, ship2.bow));
        int sign2 = Math.Sign(Determinant3x3(ship1.bow, ship1.stern, ship2.stern));

        if(det1 == 0 || det2 == 0){
            return true;
        }
        else if(sign1 != sign2){
            return true;
        }

        return false;
    }

    public static Point GeneratePoint(){
        return new Point(random.Next(0, 11), random.Next(0, 11));
    }

    public static (Point, Point) GenerateSegment(int length){
        int direction;
        Point A, B;

        do{
            direction = random.Next(2);
            A = GeneratePoint(); 

            if(direction == 0){
                B = new Point(A.x + length, A.y);
            }
            else{
                B = new Point(A.x, A.y + length); 
            }
        } 
        while (!InSquere(A, B));

        return (A, B);
    }

    public static bool InSquere(Point A, Point B){
        return (A.x >= 0 && A.x <= 10) &&
               (B.x >= 0 && B.x <= 10) &&
               (A.y >= 0 && A.y <= 10) &&
               (B.y >= 0 && B.y <= 10);
    }

    public static double Determinant3x3(Point A, Point B, Point C){
        return B.x * (C.y - A.y) + C.x * (A.y - B.y) + A.x * (B.y - C.y);
    }

    public static bool IsCollinear(Point A, Point B, Point C){
        int det = (int)Determinant3x3(A, B, C);

        return det == 0;
    }
}