import { createApp } from 'vue';
import './style.css';
import App from './App.vue';
import { router } from './router/router';
import { createPinia } from 'pinia';
import { vuetify } from './plugins/vuetify';
import firebaseApp from './firebase';

console.log('Firebase initialized', firebaseApp);

const pinia = createPinia();

createApp(App)
    .use(pinia)
    .use(router)
    .use(vuetify)
    .mount('#app')
