export class UserDto {
    email: string;
    password: string;
    username: string;
    userUid: string;

    constructor() {
        this.email = '';
        this.password = '';
        this.username = '';
        this.userUid = '';
    }
}