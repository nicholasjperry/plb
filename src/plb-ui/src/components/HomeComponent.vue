<template lang="pug">     
VContainer.v-container
    VRow(style="align-items: center; justify-content: center")
        h1.ms-8.me-4.component-header Premier League: Brawl
        img(src="/images/logo.webp" height="80" width="80")
    VRow
        VCol
            VCard.v-card(color="#d24700")
                VCardTitle.v-card-title(style="font-size: 1.5rem; text-decoration: underline") About the League 
                VCardText.v-card-text
                    | Welcome to the 
                    strong Premier League: Brawl, 
                    | a competitive yet fun-driven 
                    strong 1v1 Commander League
                    | played on MTG Arena! Our league is built for having, “more fun with the fun we have.”
                    br
                    br
                    | Each match is played in a Best-of-3 Format, with detailed post-game breakdowns ensuring 
                    | every match tells a story beyond just wins and losses. Whether you're a seasoned veteran
                    | or a rising competitor, our league offers a place to showcase your skills, track meaningful
                    | performance metrics, and enjoy the thrill of battle.
                    br
                    br
                    | Our mission is simple: 
                    strong Foster a competitive, sports-like atmosphere while keeping the game fun and engaging for everyone.
                    br
                    br
                    h3 What to Expect 
                    li
                        strong Structured Best-of-3 Matches - 
                        | Head-to-head battles in a refined competitive format based on the Beta Ruleset for the Commander Brackets.
                    li
                        strong Pageantry - 
                        | Team logos/profiles, standings, tournaments, titles, and more are included to make this truly a unique experience.
                    li
                        strong Post-Game Recaps - 
                        | Sports style breakdowns of key plays and performance highlights.
                    li
                        strong Community and Growth - 
                        | A dedicated Discord server and website for match coordination, deck discussions, and strategy talk.
    VRow
        VCol(cols="6")
            VCard.v-card(color="#545353")
                VCardTitle.v-card-title Recent Match Highlights
                VCarousel(
                    cycle
                    height="350"
                    hide-delimiter-background
                    show-arrows="hover"
                )
                    VCarouselItem.v-carousel-item(
                        v-for="image in images"
                        eager 
                        :src="image.src" 
                        @click="toggleImageDialog(image.src)"
                    )
        VCol(cols="6")
            VCard.v-card(color="#545353")
                VCardTitle.mb-4.v-card-title Most Wanted List
                VImg(src="/public//images/MostWanted1.png" height="335")
            //- TODO: Old sign-up component
            //- VCard.v-card(color="#545353")
            //-     VCardTitle.v-card-title Sign-Up
            //-     VTabs.mx-4(
            //-         v-model="tab"
            //-         bg-color="#1d264b"
            //-     )
            //-         VTab(v-for="day in days" :key="day.value") {{ day.value }}
            //-     VCardText.v-card-text
            //-         VTabsWindow(v-model="tab")
            //-             VTabsWindowItem(v-for="day in days" :key="day.value")
            //-                 .d-flex.flex-column
            //-                     .d.flex.flex-row
            //-                         VBtn.me-2(
            //-                             v-for="availableTime in availableTimes"
            //-                             color="#f72707"
            //-                             :disabled="availableTime.disabled"
            //-                             :key="availableTime.hour"
            //-                             @click="disableTime(availableTime.hour)"
            //-                         ) {{ availableTime.hour }}
VDialog(
    v-model="showImageDialog" 
    close-on-content-click
    height="85%" 
    width="85%" 
)
    VImg(:src="imageSrc")
</template>

<script setup lang="ts">
// import{ DateTime } from 'luxon';
import { ref } from 'vue';
import { 
    VCarousel, 
    // VTabsWindow, 
    // VTabsWindowItem 
} from 'vuetify/lib/components/index.mjs';

// TODO: Save for later (?)
// function getToday() {
//     const today = DateTime.now();
//     return today.toFormat('EEE MM/dd/yyyy')
// }
const imageSrc = ref<string | undefined>(undefined);

const showImageDialog = ref(false);

function toggleImageDialog(src: string) {
    imageSrc.value = src;
    showImageDialog.value = !showImageDialog.value;
}

const images = ref([
    {
        src: '/images/hubrizVsamphree.png',
    },
    {
        src: '/images/giblitsVmaxis.png',
    },
    {
        src: '/images/maxisVmeadmaker.png',
    },
]);

// TODO: Save for later (?)
// const tab = ref(null);

// const availableTimes = ref([
//     // TODO: derive from db vs. just perform getToday, getTomorrow, etc. logic (?)
//     {
//         hour: '9:00 PM',
//         disabled: false,
//     },
//     {
//         hour: '9:30 PM',
//         disabled: false,
//     },
//     {
//         hour: '10:00 PM',
//         disabled: false,
//     },
//     {
//         hour: '10:30 PM',
//         disabled: false,
//     },
// ]);

// const days = ref([
//     {
//         value: 'Sunday',
//         availableTimes: [...availableTimes.value],
//     },
//     {
//         value: 'Monday',
//         availableTimes: [...availableTimes.value],
//     },
//     {
//         value: 'Tuesday',
//         availableTimes: [...availableTimes.value],
//     },
//     {
//         value: 'Wednesday',
//         availableTimes: [...availableTimes.value],
//     },
//     {
//         value: 'Thursday',
//         availableTimes: [...availableTimes.value],
//     },
//     {
//         value: 'Friday',
//         availableTimes: [...availableTimes.value]
//     },
//     {
//         value: 'Saturday',
//         availableTimes: [...availableTimes.value],
//     },
// ]);

// function disableTime(availableTime: string) {
//     const timeFound = availableTimes.value.find((t) => t.hour === availableTime);
//     if (timeFound)
//         timeFound.disabled = true;
// }
</script>

<style lang="css">
.v-card-text {
    font-size: 1rem;
}
</style>