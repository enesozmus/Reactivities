import { User } from "./user";

export interface Profile {
    firstName: string;
    lastName: string;
    displayName: string;
    bio: string;
    userName: string;
    image?: string;
    photos?: Photo[];
}

export class Profile implements Profile {
    
    constructor(user: User) {
        this.userName = user.userName;
        this.firstName = user.firstName;
        this.lastName = user.lastName;
        this.displayName = user.displayName;
        this.bio = user.bio;
        this.image = user.image;
    }
}

export interface Photo {
    photoId: string;
    url: string;
    isMain: boolean;
}