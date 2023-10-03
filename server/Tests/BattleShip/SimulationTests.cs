using Xunit;
using ndc.Data;
using ndc.Data.Models;

namespace Contoso.Tests;

public class SimulationTests {
    public SimulationTests(){

    }

    [Fact]
    public void Game_Simulation_Ends_With_One_Player_Having_Zero_Life()
    {
        Bot player1;
        Bot player2;
        Simulation game;
        int numberOfSimulations = 100; 

        for(int i = 0; i < numberOfSimulations; i++){
            player1 = new Bot("player-1");
            player2 = new Bot("player-2");
            game = new Simulation(player1, player2);

            Assert.True(
                (player1.board.units == 0 && player2.board.units > 0) || 
                (player2.board.units == 0 && player1.board.units > 0)
            );
        }
    }
}