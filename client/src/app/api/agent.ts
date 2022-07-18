import axios, { Axios, AxiosError, AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { history } from "../..";
import { Activity, ActivityFormValues } from "../models/activity";
import { User, UserFormValues } from "../models/user";
import { store } from "../stores/store";


// loading indicator I
const sleep = (delay: number) => {
    return new Promise((resolve) => {
        setTimeout(resolve, delay)
    })
}

// Ana URL
axios.defaults.baseURL = 'http://localhost:5000/api/'

// token
axios.interceptors.request.use(config => {
    const token = store.commonStore.token;
    if (token) config.headers!.Authorization = `Bearer ${token}`
    return config;
})

// loading indicator II
axios.interceptors.response.use(async response => {

    await sleep(500);
    return response;
}, (error: AxiosError) => {

    const { data: d, status, config } = error.response!;
    let data: any = d!;

    switch (status) {
        case 400:
            if(typeof data === 'string')
            {
                toast.error(data);
            }
            if (config.method === 'get' && data.errors.hasOwnProperty('id')) {
                history.push('/not-found');
            }
            if (data.errors) {
                const modalStateErrors = [];
                for (const key in data.errors) {
                    if (data.errors[key]) {
                        modalStateErrors.push(data.errors[key])
                    }
                }
                throw modalStateErrors.flat();
            }
            else {
                toast.error(data);
            }
            break;
        case 401:
            toast.error('unauthorised')
            break;
        case 404:
            history.push('/not-found');
            break;
        case 500:
            store.commonStore.setServerError(data);
            history.push('/server-error');
            break;
    }
    return Promise.reject(error);
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
    //  hepsini listele
    list: () => requests.get<Activity[]>('activities'),
    //  ID'te göre aktivite getir
    details: (id: string) => requests.get<Activity>(`activities/${id}`),
    // aktivite ekleme
    create: (activity: ActivityFormValues) => requests.post<void>('activities', activity),
    // aktivite güncelleme
    update: (activity: ActivityFormValues) => requests.put<void>(`activities/${activity.id}`, activity),
    // aktivite silme
    delete: (id: string) => requests.del<void>(`activities/${id}`),
    attend: (id: string) => requests.post<void>(`activities/${id}/attend`, {})
}

// for => auth
const Account = {
    current: () => requests.get<User>('auth'),
    login: (user: UserFormValues) => requests.post<User>('auth/login', user),
    register: (user: UserFormValues) => requests.post<User>('auth/register', user)
}

// standart işlemler
const agent = { Activities, Account };

export default agent;
