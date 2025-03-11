import { createMemoryHistory, createRouter } from "vue-router";
import BlogComponent from "../components/BlogComponent.vue";
import HomeComponent from "../components/HomeComponent.vue";
import PlayersComponent from "../components/PlayersComponent.vue";
import StandingsComponent from "../components/StandingsComponent.vue";
import RulesComponent from '../components/RulesComponent.vue'

const routes = [
    {
        path: '/',
        component: HomeComponent,
    },
    {
        path: '/players',
        component: PlayersComponent,
    },
    {
        path: '/standings',
        component: StandingsComponent,
    },
    {
        path: '/rules',
        component: RulesComponent,
    },
    {
        path: '/blog',
        component: BlogComponent,
    },
];

export const router = createRouter({
    history: createMemoryHistory(),
    routes,
})