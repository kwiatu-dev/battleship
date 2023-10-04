<template>
    <div>
        <Statistics 
            class="flex flex-col items-center lg:flex-row lg:items-start" 
            :player="player"
            :hits="hits"
            :misses="misses"
        />
        <table class="w-full">
            <tr>
                <td>
                    <div></div>
                </td>
                <td v-for="num in size" :key="num" class="border p-4">
                    <div>{{ num }}</div>
                </td>
            </tr>
            <tr v-for="(row, y) in size" :key="y">
                <td class="border p-4">
                    <div>{{ alphabet[y] }}</div>
                </td>
                <td 
                    v-for="(col, x) in size" :key="x" 
                    class="border p-4" 
                    :class="colors[grid[size - y - 1][x]]"
                >
                    <div v-if="shots[size - y - 1][x]" class="text-xl font-bold">x</div>
                </td>
            </tr>
        </table>
        <Legend class="w-full flex flex-row flex-wrap gap-x-6 gap-y-2 my-2" />
    </div>
</template>

<script setup>
import Legend from '@/components/Blocks/Legend.vue';
import { useBattleShipStore } from '@/stores/battleship'
import Statistics from '@/components/Blocks/Statistics.vue';

const { colors } = useBattleShipStore();
const alphabet = Array.from({ length: 26 }, (_, i) => String.fromCharCode(65 + i));

const props = defineProps({
    player: Object,
    grid: Array,
    size: Number,
    shots: Array,
    hits: Number,
    misses: Number,
})
</script>

<style scoped>
    td{
        position: relative;
    }

    td:after {
        content: '';
        display: block;
        margin-top: 100%;
    }

    td > div{
        position: absolute;
        top: 0;
        left: 0;
        bottom: 0;
        right: 0;
        display: flex;
        align-items: center;
        justify-content: center;
    }
</style>