// TODO: Probably don't even need this code...
// export default class UserDao {
//     private static baseRoute = 'users';

//     static async RegisterUser(userData: { username: string, email: string, password: string }) {
//         const result = await fetch(`https://api-url.com/api/${this.baseRoute}/register`, {
//             method: 'POST',
//             headers: {
//                 'Content-Type': 'application/json',
//             },
//             body: JSON.stringify(userData),
//         });

//         if (!result.ok)
//             throw new Error('User registration failed.');

//         return result.json();
//     }
// }