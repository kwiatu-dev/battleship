using System.Data;
using ndc.Data.Models;

namespace ndc.Data;

public class Bot: Player{
    public Bot(string id): base(id){

    }

    public Point NextGuess(){
        List<List<int>> map = GenerateProbabilityMap();
        Point guess = FindMaxPropability(map);

        if(guess.x == -1 || guess.y == -1){
            throw new ArgumentException("Invalid guess coordinates");
        }

        return guess;
    }

    private Point FindMaxPropability(List<List<int>> map){
        int maxPropability = 0;
        Point p = new Point(-1, -1);

        for(int y = 0; y < Game.boardSize; y++){
            for(int x = 0; x < Game.boardSize; x++){
                if(maxPropability < map[y][x]){
                    maxPropability = map[y][x];
                    p = new Point(x, y);
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

            for(int y = 0; y < Game.boardSize; y++){
                for(int x = 0; x < Game.boardSize; x++){
                    if(shots[y][x] == false){
                        CheckAllPosibilitiesWhereShipWillFitOnBoard(x, y, useSize, map);
                    }

                    if(shots[y][x] == true && sinkings[y][x] == true){
                        IncreasePropabilityNearSuccessfulHits(x, y, map);
                    }
                    else if(shots[y][x] == true && sinkings[y][x] == false){
                        DecreasePropabilityForMisses(x, y, map);
                    }
                }
            }
        }

        return map;
    }

    private void CheckAllPosibilitiesWhereShipWillFitOnBoard(int x, int y, int size, List<List<int>> map){
        List<Tuple<Point, Point>> endpoints = new List<Tuple<Point, Point>>();
                        
        if (y - size >= 0){
            endpoints.Add(new Tuple<Point, Point>(
                new Point(x, y - size), 
                new Point(x, y)
            ));
        }

        if (y + size <= 9){
            endpoints.Add(new Tuple<Point, Point>(
                new Point(x, y), 
                new Point(x, y + size)
            ));
        }

        if (x - size >= 0){
            endpoints.Add(new Tuple<Point, Point>(
                new Point(x - size, y), 
                new Point(x, y)
            ));
        }

        if (x + size <= 9){
            endpoints.Add(new Tuple<Point, Point>(
                new Point(x, y), 
                new Point(x + size, y)
            ));
        }

        foreach ((Point bow, Point stern) in endpoints){
            bool zeros = true;

            for (int i = bow.y; i <= stern.y; i++){
                for (int j = bow.x; j <= stern.x; j++){
                    if (shots[i][j] == true){
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

    private void IncreasePropabilityNearSuccessfulHits(int x, int y, List<List<int>> map){
        if(y + 1 < Game.boardSize && shots[y + 1][x] == false){
            if(y - 1 >= 0 && sinkings[y - 1][x] == true){
                map[y + 1][x] += 15;
            }
            else{
                map[y + 1][x] += 10;
            }
        }

        if(y - 1 >= 0 && shots[y - 1][x] == false){
            if(y + 1 < Game.boardSize && sinkings[y + 1][x] == true){
                map[y - 1][x] += 15;
            }
            else{
                map[y - 1][x] += 10;
            }
        }

        if(x + 1 < Game.boardSize && shots[y][x + 1] == false){
            if(x - 1 >= 0 && sinkings[y][x - 1] == true){
                map[y][x + 1] += 15;
            }
            else{
                map[y][x + 1] += 10;
            }
        }

        if(x - 1 >= 0 && shots[y][x - 1] == false){
            if(x + 1 < Game.boardSize && sinkings[y][x + 1] == true){
                map[y][x - 1] += 15;
            }
            else{
                map[y][x - 1] += 10;
            }
        }
    }

    private void DecreasePropabilityForMisses(int x, int y, List<List<int>> map){
        map[y][x] = 0;
    }
}