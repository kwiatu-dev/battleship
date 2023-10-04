<template>
    <div class="border border-black mt-2 p-4">
        <ul>
            <li v-for="(item, index) in reverseRounds()" :key="index">
                <span class="text-gray-300 font-medium">{{ rounds.length - index }}: </span>
                <span>Player </span>
                <span class="font-bold">{{ item.playerId }}</span>
                <span> fired a projectile at coordinates </span>
                <span class="font-bold">{{ alphabet[size - item.shot.y - 1] }}{{ item.shot.x + 1 }}</span>
                <span> and </span>
                <span>{{ item.hit ? 'hit' : 'missed' }} </span>
                <span>{{ item.sunk ? ', sinking the entire ship' : ''}} </span>
                <span v-if="item.hit" class="inline-block rounded-full w-3 h-3 ml-2 bg-green-400"></span>
                <span v-if="!item.hit" class="inline-block rounded-full w-3 h-3 ml-2 bg-red-600"></span>
            </li>
        </ul>
    </div>
</template>

<script setup>
const props = defineProps({
    rounds: Array,
    size: Number,
})

const alphabet = Array.from({ length: 26 }, (_, i) => String.fromCharCode(65 + i));

const reverseRounds = () => {
    return [...props.rounds].reverse();
}
</script>