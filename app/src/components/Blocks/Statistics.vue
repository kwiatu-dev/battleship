<template>
    <div>
        <div class="lg:w-3/12 text-xl font-medium uppercase ml-14">{{ player.id }}</div>
        <div class="lg:w-9/12 flex flex-row justify-end gap-4">
            <div>
                <span class="font-bold">x</span>
                <span class="ml-2">Shots: {{ hits + misses }}</span>
            </div>
            <div>
                <span class="inline-block rounded-full w-3 h-3 bg-green-400"></span>
                <span class="ml-2">Hits: {{ hits }}</span>
            </div>
            <div>
                <span class="inline-block rounded-full w-3 h-3 bg-red-600"></span>
                <span class="ml-2">Misses: {{ misses }}</span>
            </div>
        </div>
    </div>
</template>

<script setup>
defineProps({
    hits: Number,
    misses: Number,
    player: Object,
})
</script>