<script setup>
// import { useBattleShipStore } from '@/stores/battleship'

// const { getBattleShipData, battleship } = useBattleShipStore();
// await getBattleShipData();

const endpoint = location.hostname.indexOf("localhost") >=0 ? "http://localhost:8000/api/battleship" : "/api/battleship"
const res = await fetch(endpoint);
const battleship = await res.json();

const colors = {
   "Carrier": 'bg-red-900',
   "Battleship": 'bg-amber-400',
   "Destroyer": 'bg-lime-600',
   "Submarine": 'bg-emerald-600',
   "Patrol Boat": 'bg-indigo-700',
}

const size = battleship.value.player1.board.size
const grid1 = battleship.value.player1.board.grid
const grid2 = battleship.value.player2.board.grid

console.log(battleship.value.history)
</script>

<template>
    <div class="container h-screen flex items-center mx-auto">
        <div class="flex flex-row flex-nowrap gap-8">
            <div class="w-1/2">
                <div class="w-full text-xl font-medium text-center">PLAYER 1</div>
                <table class="w-full table-fixed">
                    <tr>
                        <td></td>
                        <td v-for="num in size" :key="num" class="text-center p-4">{{ num }}</td>
                    </tr>
                    <tr v-for="(row, y) in size" :key="y">
                        <td class="text-center p-4">1</td>
                        <td 
                        v-for="(col, x) in size" :key="x" 
                        class="border text-center p-4" 
                        :class="colors[grid1[size - y - 1][x]]"
                        >
                            <div></div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="w-1/2">
                <div class="w-full text-xl font-medium text-center">PLAYER 2</div>
                <table class="w-full table-fixed">
                    <tr>
                        <td></td>
                        <td v-for="num in size" :key="num" class="text-center p-4">{{ num }}</td>
                    </tr>
                    <tr v-for="(row, y) in size" :key="y">
                        <td class="text-center p-4">1</td>
                        <td 
                        v-for="(col, x) in size" :key="x" 
                        class="border text-center p-4"
                        :class="colors[grid2[size - y - 1][x]]"
                        >
                            <div></div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</template>

