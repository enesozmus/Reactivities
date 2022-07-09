import axios, { AxiosResponse } from "axios";
import { Activity } from "../models/activity";


// loading indicator I
const sleep = (delay: number) => {
    return new Promise((resolve) => {
        setTimeout(resolve, delay)
    })
}

// Ana URL
axios.defaults.baseURL = 'http://localhost:5000/api/'

// loading indicator II
axios.interceptors.response.use(async response => {
    try
    {
        await sleep(500);
        return response;
    }
    catch (error)
    {
        console.log(error);
        return await Promise.reject(error);
    }
})


// standart işlemler
//const responseBody = (response: AxiosResponse) => response.data;
const responseBody = <T>(response: AxiosResponse<T>) => response.data;



// GET, POST, PUT, DELETE
const requests = {
    // standart => [HttpGet]
    //get: (url: string) => axios.get(url).then(responseBody),
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),

    // standart => [HttpPost]
    post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),

    // standart => [HttpPut]
    put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),

    // standart => [HttpDelete]
    del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
}


// for => activities
const Activities = {
    //hepsini listele
    //list: () => requests.get('activities')
    list: () => requests.get<Activity[]>('activities')
}


// standart işlemler
const agent = { Activities };

export default agent;
