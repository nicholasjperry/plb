<template lang="pug">
VContainer.v-container
    VRow
        VCol
            h1.component-header Players
    VRow
        VCol(cols="3" v-for="player in players" :key="player.name")
            VCard.pa-3.v-card(color="#545353")
                .d-flex.flex-column.align-center
                    VCardTitle.v-card-title {{ player.name }}
                    img(:src="player.avatar" height="200" width="200")
</template>

<script setup lang="ts">
import { ref } from 'vue';
// TODO: get player data into db

const players = ref([
    {
        name: '2Frames',
        avatar: '/images/2Frames.png',
    },
    {
        name: 'Giblits',
        avatar: '/images/Giblits.png',
    },
    {
        name: 'Hubriz',
        avatar: '/images/Hubriz.png',
    },
    {
        name: 'Keerplunk',
        avatar: '/images/Keerplunk.png',
    },
    {
        name: 'Maxis',
        avatar: '/images/Maxis.png',
    },
    {
        name: 'Meadmaker',
        avatar: '/images/Meadmaker.png',
    },
    {
        name: 'Notorious',
        avatar: '/images/Notorious.png',
    },
    {
        name: 'Phyllis',
        avatar: '/images/Phyllis.png',
    },
    {
        name: 'Raga',
        avatar: '/images/Raga.png',
    },
    {
        name: 'Samphree',
        avatar: '/images/Samphree.png',
    },
    {
        name: 'Verified',
        avatar: '/images/Verified.png',
    },
]);
</script>

<style scoped lang="css">
.v-card:hover {
    cursor: pointer;
    transform: scale(1.02);
}
</style>