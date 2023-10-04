<template>
    <ul>
        <li v-for="(color, type) in colors" :key="type" class="flex flex-row items-center gap-2">
            <span class="rounded-full w-4 h-4 inline-block" :class="color"></span>
            {{ type }}
        </li>
    </ul>
</template>

<script setup>
import { useBattleShipStore } from '@/stores/battleship'

const { colors } = useBattleShipStore();
</script>