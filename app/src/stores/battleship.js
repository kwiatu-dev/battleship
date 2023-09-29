import { defineStore } from 'pinia'

export const useBattleShipStore = defineStore('battleship', {
  state(){
    return {
      battleship: {},
    }
  },
  getters:{
    
  },
  actions:{
    async getBattleShipData(){
        const endpoint = location.hostname.indexOf("localhost") >=0 ? "http://localhost:8000/api/battleship" : "/api/battleship"

        try{
            const res = await fetch(endpoint);
            this.battleship = await res.json();
            //console.log(this.battleship)
        }
        catch(err){
            console.error(err);
        }
    }
  }
});
