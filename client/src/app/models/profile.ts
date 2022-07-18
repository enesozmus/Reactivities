import { User } from "./user";

export interface Profile {
    firstName: string;
    lastName: string;
    userName: string;
    image?: string;
}

export class Profile implements Profile {
    constructor(user: User) {
        this.userName = user.userName;
        this.firstName = user.firstName;
        this.lastName = user.lastName;
        this.image = user.image;
    }
}