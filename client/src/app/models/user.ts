export interface User {
    firstName: string;
    lastName: string;
    userName: string;
    email: string;
    phoneNumber: string;
    password: string;
    token: string;
    image?: string;
    
}

export interface UserFormValues {
    email: string;
    password: string;
    username?: string;
}