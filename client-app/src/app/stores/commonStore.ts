import { makeAutoObservable, reaction } from "mobx";
import { ServerError } from "../models/serverError";

export default class CommonStore {
    error: ServerError | null = null;
    token: string | null = window.localStorage.getItem('jwt');
    appLoaded: boolean = false;
    
    constructor() {
        makeAutoObservable(this);

        // implementation of reaction on mobx. Checks if token is updated and updates local storage.
        // This reaction does not run when store initially loads. Token will be null initially first time or set to whats stored in local storage.
        // It will however run if the token then is changed afterwards.  
        reaction(
            () => this.token, // what to react to
            token => {
                if (token) {
                    console.log('commonStore.ts: reaction log: token is set');
                    window.localStorage.setItem('jwt', token);
                } else {
                    console.log('commonStore.ts: reaction log: token is not set');
                    window.localStorage.removeItem('jwt');
                }
            }
        )
    }

    setServerError = (error: ServerError) => {
        this.error = error;
    }

    setToken = (token: string | null) => {
        this.token = token;
    }

    setAppLoaded = () => {
        this.appLoaded = true;
    }
}