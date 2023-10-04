<template>
    <div class="container flex flex-col items-center justify-center mx-auto px-4 my-32">
        <div class="w-full flex flex-col items-center md:flex-row md:flex-nowrap md:justify-center gap-8">
            <Board 
                class="flex-1" 
                :player="game.player1" 
                :grid="game.grid1" 
                :size="game.size" 
                :shots="game.shots2" 
                :hits="game.hits2" 
                :misses="game.misses2" 
            />
            <Board 
                class="flex-1" 
                :player="game.player2" 
                :grid="game.grid2" 
                :size="game.size" 
                :shots="game.shots1" 
                :hits="game.hits1" 
                :misses="game.misses1" 
            />
        </div>
        <div class="w-full flex flex-col">
            <div class="mx-auto mt-6">
                <button 
                    @click="next" 
                    class="text-white bg-green-600 border-0 py-2 px-6 focus:outline-none hover:bg-green-700 text-lg"
                >
                    {{ 
                        game.winner === null? 
                        `${game.turn.id} makes a move` : 
                        `${game.winner} win` 
                    }} 
                </button>
                <button 
                    v-if="game.rounds.length === game.history.length"
                    class="ml-2 text-gray-500 font-medium"
                    @click="reset"
                >Reset</button>
            </div>
            <Rounds 
                :size="game.size" 
                :rounds="game.rounds" 
            />
        </div>
    </div>
</template>

<script setup>
import Board from '@/components/Blocks/Board.vue';
import Rounds from '@/components/Blocks/Rounds.vue';
import { useBattleShipStore } from '@/stores/battleship'

const { battleship } = useBattleShipStore();
const game = await battleship

const next = () => {
    if(game.round >= game.history.length) return;
    const item = game.history[game.round]
    game.rounds.push(item);

    if(item.playerId === game.player1.id){
        game.shots1[item.shot.y][item.shot.x] = true 
        game.turn = game.player2

        if(item.hit) 
            game.hits1++
        else 
            game.misses1++
    }
    else if(item.playerId === game.player2.id){
        game.shots2[item.shot.y][item.shot.x] = true 
        game.turn = game.player1

        if(item.hit) 
            game.hits2++
        else 
            game.misses2++
    }

    if(++game.round === game.history.length) 
        game.winner = item.playerId
}

const reset = () => {
    location.reload()
}
</script>


