using ndc.Data.Models;

namespace ndc.Data;

public class Bot: Player{
    public Point guess { get; set; }
    public Bot(string id): base(id){

    }

    public Point NextGuess(){
        GenerateProbabilityMap();

        return guess;
    }

    private void GenerateProbabilityMap(){
        List<List<int>> map = Helpers.Initialize2DListWithValues(Game.boardSize, 0);
        int maxPropability = 0;

        foreach(KeyValuePair<string, int> kvp in Game.ships){
            int shipSize = kvp.Value;
            int useSize = shipSize - 1;

            for(int row = 0; row < Game.boardSize; row++){
                for(int col = 0; col < Game.boardSize; col++){
                    if(shots[row][col] != true){
                        List<Tuple<Point, Point>> endpoints = new List<Tuple<Point, Point>>();
                        
                        if (row - useSize >= 0){
                            endpoints.Add(new Tuple<Point, Point>(
                                new Point(row - useSize, col), 
                                new Point(row, col)
                            ));
                        }

                        if (row + useSize <= 9){
                            endpoints.Add(new Tuple<Point, Point>(
                                new Point(row, col), 
                                new Point(row + useSize, col)
                            ));
                        }

                        if (col - useSize >= 0){
                            endpoints.Add(new Tuple<Point, Point>(
                                new Point(row, col - useSize), 
                                new Point(row, col)
                            ));
                        }

                        if (col + useSize <= 9){
                            endpoints.Add(new Tuple<Point, Point>(
                                new Point(row, col), 
                                new Point(row, col + useSize)
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
                                        if(maxPropability < ++map[i][j]){
                                            guess = new Point(j, i);
                                            maxPropability = map[i][j];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}