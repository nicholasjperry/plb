<template lang="pug">
VApp(id="app")
    VAppBar.v-app-bar
        RouterLink(to="/" active-class="home-router-link-active")
            img(src="/images/logo.webp" height="50" width="50")
        VSpacer
        RouterLink.route(to="/" active-class="home-router-link-active") Home
        RouterLink.route(to="/players") Players
        RouterLink.route(to="/standings") Standings
        RouterLink.route(to="/rules") Rules
        RouterLink.route(to="/blog") Blog
        VBtn.me-2(
            v-if="!hasValidSession"
            color="#f72707"
            variant="flat"
            @click="toggleRegisterDialog"
        ) Register
        VBtn(
            v-if="!hasValidSession"
            color="#fff"
            variant="flat"
            @click="toggleLoginDialog"
        ) Login
    RouterView
VDialog.h-100(
    v-model="showDialog"
)
    .d-flex.flex-row.justify-center
        VCard(
            height="475"
            width="450"
        )
            VTabs(
                v-model="tab"
                align-tabs="center"
            )
                VTab(value="register") Register
                VTab(value="login") Login
            VCardText
                VTabsWindow(v-model="tab")
                    VTabsWindowItem(value="register")
                        VContainer
                            VTextField(
                                v-model="authStore.user.username"
                                label="Username"
                            )
                            VTextField(
                                v-model="authStore.user.email"
                                label="Email"
                            )
                            VTextField.register-password-field(
                                v-model="authStore.user.password"
                                label="Password"
                                :type="showRegisterPassword ? 'text' : 'password'"
                            )
                                template(#append-inner)
                                    VBtn(
                                        variant="plain"
                                        :ripple="false"
                                        @click="toggleShowRegisterPassword"
                                    )
                                        VIcon {{ showRegisterPassword ? 'mdi-eye-outline' : 'mdi-eye-closed' }}
                            VBtn.w-100(
                                color="#1d264b"
                                height="50"
                                @click="handleRegister"
                            ) Submit
                            VBtn.w-100.mt-4(
                                color="#808080"
                                height="50"
                                @click="closeDialog"
                            ) Cancel 
                    VTabsWindowItem(value="login")
                        VContainer
                            VTextField(
                                v-model="authStore.user.username"
                                label="Username"
                            )
                            VTextField.login-password-field(
                                v-model="authStore.user.password"
                                label="Password"
                                :type="showLoginPassword ? 'text' : 'password'"
                            )
                                template(#append-inner)
                                    VBtn(
                                        variant="plain"
                                        :ripple="false"
                                        @click.prevent="toggleShowLoginPassword"
                                    )
                                        VIcon {{ showLoginPassword ? 'mdi-eye-outline' : 'mdi-eye-closed' }}
                            VSpacer
                            VBtn.w-100(
                                color="#1d264b"
                                height="50"
                                @click="handleLogin"
                            ) Submit
                            VBtn.w-100.mt-4(
                                color="#808080"
                                height="50"
                                @click="closeDialog"
                            ) Cancel 
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { RouterView } from 'vue-router';
import { useAuthStore } from './stores/AuthStore';
import { RegisterUserDto } from './dtos/RegisterUserDto';

// #region Stores

const authStore = useAuthStore();

// #endregion

const showDialog = ref(false);
const tab = ref<string | null>(null);
const hasValidSession = ref(false);

// #region Register

const showRegisterPassword = ref(false);

function toggleRegisterDialog() {
    showDialog.value = !showDialog.value;
    tab.value = 'register';
}

function handleRegister() {
    authStore.registerUser(authStore.user.email, authStore.user.password, authStore.user.username);
}

function toggleShowRegisterPassword() {
    showRegisterPassword.value = !showRegisterPassword.value;
}

function closeDialog() {
    showDialog.value = false;
    authStore.user = new RegisterUserDto();
}

// #endregion

// #region Login

const showLoginPassword = ref(false);

function toggleLoginDialog() {
    showDialog.value = !showDialog.value;
    tab.value = 'login';
}

function handleLogin() {
    authStore.loginUser();
}

function toggleShowLoginPassword() {
    showLoginPassword.value = !showLoginPassword.value;
}

// #endregion

// Color Palette:
// #1d264b Blue - main bg/accent
// #f72707 Red - use for highlights, buttons, emphasis
// #ff7405 / #d24700 Orange - secondary accent or call-to-action like sign up
// #f0a855 Gold - borders, dividers, special messages
// #545353 Gray - neutral bg color
// #fff White - white text will most likely be the winner
</script>

<style lang="css">
</style>
