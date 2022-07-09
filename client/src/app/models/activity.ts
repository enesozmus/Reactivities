export interface Activity {

    id: string;
    title: string;
    date: Date | null | string | any;
    description: string;
    category: string;
    city: string;
    venue: string;
    //isCancelled: boolean;
}