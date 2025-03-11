import { defineStore } from "pinia";
import { UserDto } from "../dtos/UserDto";
// import { v4 as newGuid } from 'uuid';
import UserDao from "../daos/UserDao";

export const useAuthStore = defineStore('auth', () => {
    const user = new UserDto();
    const dao = UserDao;

    function loginUser() {
        console.log('Login clicked');
    }

    async function registerUser() {
        console.log('Register clicked');
        const result = await dao.RegisterUser(user); 
        return result;
    }

    return {
        loginUser,
        registerUser,
        user,
    }
});