import { defineStore } from 'pinia'
import { reactive } from 'vue'

export const useBattleShipStore = defineStore('battleship', {
  state(){
    return {
      
    }
  },
  getters:{
    colors(){
      return {
        "Carrier": 'bg-red-900',
        "Battleship": 'bg-amber-400',
        "Destroyer": 'bg-lime-600',
        "Submarine": 'bg-emerald-600',
        "Patrol Boat": 'bg-indigo-700',
     }
    },
    async battleship(){
      const endpoint = location.hostname.indexOf("localhost") >=0 ? "http://localhost:8000/api/battleship" : "/api/battleship"

      try{
          const res = await fetch(endpoint)
          const battleship = await res.json()
          
          const game = reactive({
            size: battleship.value.player1.board.size,
            player1: battleship.value.player1,
            player2: battleship.value.player2,
            grid1: battleship.value.player1.board.grid,
            grid2: battleship.value.player2.board.grid,
            history: battleship.value.history,
            turn: battleship.value.history[0].playerId === battleship.value.player1.id ? battleship.value.player1 : battleship.value.player2,
            round: 0,
            rounds: [],
            shots1: Array.from({ length: battleship.value.player1.board.size }, () => Array(battleship.value.player1.board.size).fill(false)),
            shots2: Array.from({ length: battleship.value.player2.board.size }, () => Array(battleship.value.player2.board.size).fill(false)),
            hits1: 0,
            hits2: 0,
            misses1: 0,
            misses2: 0,
            winner: null,
          })

          return game
      }
      catch(err){
          console.error(err);
      }
    }
  },
  actions:{
    
  }
});
