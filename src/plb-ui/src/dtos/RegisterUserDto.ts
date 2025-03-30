export class RegisterUserDto {
    email: string;
    password: string;
    username: string;

    constructor() {
        this.email = '';
        this.password = '';
        this.username = '';
    }
}