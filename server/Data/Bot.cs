using System.Data;
using ndc.Data.Models;

namespace ndc.Data;

public class Bot: Player{
    public Bot(string id): base(id){

    }

    public Point NextGuess(){
        List<List<int>> map = GenerateProbabilityMap();

        return FindMaxPropability(map);
    }

    private Point FindMaxPropability(List<List<int>> map){
        int maxPropability = -1;
        Point p = new Point(-1, -1);

        for(int row = 0; row < Game.boardSize; row++){
            for(int col = 0; col < Game.boardSize; col++){
                if(maxPropability < map[row][col]){
                    maxPropability = map[row][col];
                    p = new Point(col, row);
                }
            }
        }

        return p;
    }

    private List<List<int>> GenerateProbabilityMap(){
        List<List<int>> map = Helpers.Initialize2DListWithValues(Game.boardSize, 0);

        foreach(KeyValuePair<string, int> kvp in Game.ships){
            int shipSize = kvp.Value;
            int useSize = shipSize - 1;

            for(int row = 0; row < Game.boardSize; row++){
                for(int col = 0; col < Game.boardSize; col++){
                    if(shots[row][col] == false){
                        CheckAllPosibilitiesWhereShipWillFitOnBoard(row, col, useSize, map);
                    }

                    if(shots[row][col] == true && sinkings[row][col] == true){
                        IncreasePropabilityNearSuccessfulHits(row, col, map);
                    }

                    if(shots[row][col] == true && sinkings[row][col] == false){
                        DecreasePropabilityForMisses(row, col, map);
                    }
                }
            }
        }

        return map;
    }

    private void CheckAllPosibilitiesWhereShipWillFitOnBoard(int row, int col, int size, List<List<int>> map){
        List<Tuple<Point, Point>> endpoints = new List<Tuple<Point, Point>>();
                        
        if (row - size >= 0){
            endpoints.Add(new Tuple<Point, Point>(
                new Point(row - size, col), 
                new Point(row, col)
            ));
        }

        if (row + size <= 9){
            endpoints.Add(new Tuple<Point, Point>(
                new Point(row, col), 
                new Point(row + size, col)
            ));
        }

        if (col - size >= 0){
            endpoints.Add(new Tuple<Point, Point>(
                new Point(row, col - size), 
                new Point(row, col)
            ));
        }

        if (col + size <= 9){
            endpoints.Add(new Tuple<Point, Point>(
                new Point(row, col), 
                new Point(row, col + size)
            ));
        }

        foreach ((Point bow, Point stern) in endpoints){
            bool zeros = true;

            for (int i = bow.y; i <= stern.y; i++){
                for (int j = bow.x; j <= stern.x; j++){
                    if (shots[i][j] != false){
                        zeros = false;
                        break;
                    }
                }

                if (!zeros) break;
            }

            if (zeros){
                for (int i = bow.y; i <= stern.y; i++){
                    for (int j = bow.x; j <= stern.x; j++){
                        map[i][j]++;
                    }
                }
            }
        }
    }

    private void IncreasePropabilityNearSuccessfulHits(int row, int col, List<List<int>> map){
        if(row + 1 < Game.boardSize && shots[row + 1][col] == false){
            if(row - 1 >= 0 && sinkings[row - 1][col] == true){
                map[row + 1][col] += 15;
            }
            else{
                map[row + 1][col] += 10;
            }
        }

        if(row - 1 >= 0 && shots[row - 1][col] == false){
            if(row + 1 < Game.boardSize && sinkings[row + 1][col] == true){
                map[row - 1][col] += 15;
            }
            else{
                map[row - 1][col] += 10;
            }
        }

        if(col + 1 < Game.boardSize && shots[row][col + 1] == false){
            if(col - 1 >= 0 && sinkings[row][col - 1] == true){
                map[row][col + 1] += 15;
            }
            else{
                map[row][col + 1] += 10;
            }
        }

        if(col - 1 >= 0 && shots[row][col - 1] == false){
            if(col + 1 < Game.boardSize && sinkings[row][col + 1] == true){
                map[row][col - 1] += 15;
            }
            else{
                map[row][col - 1] += 10;
            }
        }
    }

    private void DecreasePropabilityForMisses(int row, int col, List<List<int>> map){
        map[row][col] = 0;
    }
}