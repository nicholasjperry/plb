import { defineStore } from "pinia";
import { UserDto } from "../dtos/UserDto";
// import { v4 as newGuid } from 'uuid';
import { createUserWithEmailAndPassword, getAuth } from "firebase/auth";

export const useAuthStore = defineStore('auth', () => {
    const user = new UserDto();

    function loginUser() {
        console.log('Login clicked');
    }

    async function registerUser(email: string, password: string) {
        try {
            const auth = getAuth();
            const userCredential = await createUserWithEmailAndPassword(auth, email, password);
            const user = userCredential.user;
            const token = await user.getIdToken();
            // await sendTokenToBackend(token, email);
        }
        catch(err) {
            console.error(err);
        }
    }

    // TODO: work on getting the API url next...
    // async function sendTokenToBackend() {
    //     const result = await fetch('https://')
    // }

    return {
        loginUser,
        registerUser,
        user,
    }
});