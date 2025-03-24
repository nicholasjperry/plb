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
            await sendTokenToBackend(email, token);
        }
        catch(err) {
            console.error(err);
        }
    }

    async function sendTokenToBackend(email: string, token: string) {
        try {
            // TODO: setup API endpoint
            const response = await fetch('https://localhost:7110/api/users/register', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                },
                body: JSON.stringify({ email }),
            });
    
            const result = await response.json();
    
            if (result.ok) {
                console.log(result);
                return result;
            }
            else
                throw new Error('Registration failed.');
        }
        catch (err) {
            console.error('Error during registration: ', err);
            throw err;
        }
    }

    return {
        loginUser,
        registerUser,
        user,
    }
});