using Xunit;
using ndc.Data;
using ndc.Data.Models;

namespace Contoso.Tests;

public class HelpersTests {
    public HelpersTests(){

    }

    [Fact]
    public void IsPointOnSegment_Return_True_For_Point_On_Segment(){
        Point A = new Point(1, 1);
        Point B = new Point(5, 1);
        Point C = new Point(3, 1);

        bool result = Helpers.IsPointOnSegment(A, B, C);

        Assert.True(result);
    }

    [Fact]
    public void IsPointOnSegment_Return_False_For_Point_On_Segment(){
        Point A = new Point(0, 5);
        Point B = new Point(5, 5);
        Point C = new Point(6, 5);

        bool result = Helpers.IsPointOnSegment(A, B, C);

        Assert.False(result);
    }

    [Fact]
    public void IsSegmentInSquere_Returns_True_For_Segment_Inside_Square(){
        Point A = new Point(3, 5);
        Point B = new Point(6, 5);

        bool result = Helpers.IsSegmentInSquere(A, B);

        Assert.True(result);
    }

    [Fact]
    public void IsSegmentInSquere_Returns_False_For_Segment_Outside_Square(){
        Point A = new Point(-3, 5);
        Point B = new Point(3, 5);

        bool result = Helpers.IsSegmentInSquere(A, B);

        Assert.False(result);
    }

    [Fact]
    public void Det_Returns_Correct_Determinant()
    {
        Point A = new Point(1, 2);
        Point B = new Point(3, 4);
        Point C = new Point(5, 6);

        int det = Helpers.Det(A, B, C);

        Assert.Equal(0, det);
    }

    [Fact]
    public void IsCollinear_Returns_True_For_Collinear_Points(){
        Point A = new Point(0, 5);
        Point B = new Point(5, 5);
        Point C = new Point(6, 5);

        bool result = Helpers.IsCollinear(A, B, C);

        Assert.True(result);
    }

    [Fact]
    public void IsCollinear_Returns_False_For_NonCollinear_Points(){
        Point A = new Point(0, 5);
        Point B = new Point(5, 5);
        Point C = new Point(6, 6);

        bool result = Helpers.IsCollinear(A, B, C);

        Assert.False(result);
    }

    [Fact]
    public void GeneratePoint_Returns_Point_Within_Board_Size(){
        Point p = Helpers.GeneratePoint();

        Assert.InRange(p.x, 0, Game.boardSize - 1);
        Assert.InRange(p.y, 0, Game.boardSize - 1);
    }

    [Fact]
    public void GenerateSegment_Returns_Segment_Within_Board_Size(){
        (Point A, Point B) = Helpers.GenerateSegment(5);

        Assert.InRange(A.x, 0, Game.boardSize - 1);
        Assert.InRange(A.y, 0, Game.boardSize - 1);
        Assert.InRange(B.x, 0, Game.boardSize - 1);
        Assert.InRange(B.y, 0, Game.boardSize - 1);

        int actualLength = Math.Max(Math.Abs(A.x - B.x), Math.Abs(A.y - B.y)) + 1;
        Assert.Equal(5, actualLength);
    }

    [Fact]
    public void IsShipsEndpointsIntersecting_Returnts_True_For_Ships_Endpoints_Intersecting(){
        Point bow1 = new Point(3, 1);
        Point stern1 = new Point(4, 1);
        Ship ship1 = new Ship("Partol Boat", 2, bow1, stern1);

        Point bow2 = new Point(1, 1);
        Point stern2 = new Point(5, 1);
        Ship ship2 = new Ship("Carrier", 5, bow2, stern2);

        bool result = Helpers.IsShipsEndpointsIntersecting(ship1, ship2);

        Assert.True(result);
    }

    [Fact]
    public void IsShipsEndpointsIntersecting_Returnts_False_For_Ships_Endpoints_Intersecting(){
        Point bow1 = new Point(3, 1);
        Point stern1 = new Point(4, 1);
        Ship ship1 = new Ship("test", 2, bow1, stern1);

        Point bow2 = new Point(5, 1);
        Point stern2 = new Point(9, 1);
        Ship ship2 = new Ship("test", 4, bow2, stern2);

        bool result = Helpers.IsShipsEndpointsIntersecting(ship1, ship2);

        Assert.False(result);
    }

    [Fact]
    public void IsShipIntersecting_Returns_True_For_Intersecting_Ships(){
        Point bow1 = new Point(3, 5);
        Point stern1 = new Point(6, 5);
        Ship ship1 = new Ship("test", 3, bow1, stern1);

        Point bow2 = new Point(5, 3);
        Point stern2 = new Point(5, 8);
        Ship ship2 = new Ship("test", 5, bow2, stern2);

        bool result = Helpers.IsShipIntersecting(ship1, ship2);

        Assert.True(result);
    }

    [Fact]
    public void IsShipIntersecting_Returns_False_For_Non_Intersecting_Ships(){
        Point bow1 = new Point(1, 1);
        Point stern1 = new Point(1, 3);
        Ship ship1 = new Ship("test", 3, bow1, stern1);

        Point bow2 = new Point(4, 4);
        Point stern2 = new Point(4, 6);
        Ship ship2 = new Ship("test", 2, bow2, stern2);

        bool result = Helpers.IsShipIntersecting(ship1, ship2);

        Assert.False(result);
    }

    [Fact]
    public void IsShipIntersectingWithOthers_Returns_True_When_NewShip_Intersects_With_Other_Ships(){
        Player player = new Player("test");

        Ship ship1 = new Ship("test", 3, new Point(2, 2), new Point(2, 5));
        Ship ship2 = new Ship("test", 3, new Point(1, 3), new Point(4, 3));
        Ship ship3 = new Ship("test", 2, new Point(7, 7), new Point(9, 7));

        player.board.ships.Add(ship1);
        player.board.ships.Add(ship2);
        player.board.ships.Add(ship3);

        Ship newShip = new Ship("test", 3, new Point(2, 3), new Point(5, 3));

        bool result = Helpers.IsShipIntersectingWithOthers(newShip, player);

        Assert.True(result);
    }

    [Fact]
    public void IsShipIntersectingWithOthers_Returns_False_When_NewShip_Does_Not_Intersect_With_Other_Ships(){
        Player player = new Player("test");

        Ship ship1 = new Ship("test", 3, new Point(2, 2), new Point(2, 5));
        Ship ship2 = new Ship("test", 3, new Point(1, 3), new Point(4, 3));
        Ship ship3 = new Ship("test", 2, new Point(7, 7), new Point(9, 7));

        player.board.ships.Add(ship1);
        player.board.ships.Add(ship2);
        player.board.ships.Add(ship3);

        Ship newShip = new Ship("test", 3, new Point(6, 6), new Point(6, 9));

        bool result = Helpers.IsShipIntersectingWithOthers(newShip, player);

        Assert.False(result);
    }

    [Fact]
    public void GenerateShipWithoutIntersection_Generates_Ship_Without_Intersection(){
        Player player = new Player("test");

        Ship ship1 = new Ship("test", 3, new Point(2, 2), new Point(2, 5));
        Ship ship2 = new Ship("test", 3, new Point(1, 3), new Point(4, 3));
        Ship ship3 = new Ship("test", 2, new Point(7, 7), new Point(9, 7));

        player.board.ships.Add(ship1);
        player.board.ships.Add(ship2);
        player.board.ships.Add(ship3);

        Ship newShip = Helpers.GenerateShipWithoutIntersection(player, "type", 4);
        bool intersects = false;

        foreach(Ship existingShip in player.board.ships){
            intersects = Helpers.IsShipIntersecting(newShip, existingShip);
            if(intersects) break;
        }

        Assert.False(intersects);
    }

    [Fact]
    public void Initialize2DListWithValues_Initializes_2D_List_With_Expected_Values(){
        int size = Game.boardSize;
        int expectedValue = 0;

        List<List<int>> initializedList = Helpers.Initialize2DListWithValues(size, expectedValue);

        Assert.Equal(size, initializedList.Count);

        foreach(List<int> row in initializedList){
            Assert.Equal(size, row.Count);

            foreach(int value in row){
                Assert.Equal(expectedValue, value);
            }
        }
    }
}