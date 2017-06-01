import { Injectable } from "@angular/core";
import { Http, Headers, Response } from "@angular/http";
import { Router } from '@angular/router';

import { Observable } from "rxjs/Observable";

import { environment } from '../environments/environment';
import { Token } from "./Model/Token";

@Injectable()
export class AuthHttp {

    constructor(private http: Http, private router: Router) {
    }

    get(url, opts = {}) {
        this.configureAuth(opts);
        return this.http.get(url, opts).catch(this.handleError());
    }

    post(url, data, opts = {}) {
        this.configureAuth(opts);
        return this.http.post(url, data, opts).catch(this.handleError());
    }

    put(url, data, opts = {}) {
        this.configureAuth(opts);
        return this.http.put(url, data, opts).catch(this.handleError());
    }

    delete(url, opts = {}) {
        this.configureAuth(opts);
        return this.http.delete(url, opts).catch(this.handleError());
    }

    configureAuth(opts: any) {
        var i = localStorage.getItem(environment.authKey);
        if (i != null) {
            var auth = JSON.parse(i);
            console.log(auth);
            if (auth.access_token != null) {
                if (opts.headers == null) {
                    opts.headers = new Headers();
                }

                opts.headers.set("Authorization", `Bearer ${auth.access_token}`);
            }
        }
    }

    // Persist auth into localStorage or removes it if a NULL argument is given
    public setAuth(auth: Token): boolean {
        if (auth) {
            localStorage.setItem(environment.authKey, JSON.stringify(auth));
        }
        else {
            localStorage.removeItem(environment.authKey);
        }
        return true;
    }

    // Retrieves the auth JSON object (or NULL if none)
    getTokenFromStorage(): Token {
        var item = localStorage.getItem(environment.authKey);
        if (item) {
            return JSON.parse(item);
        }
        else {
            return null;
        }
    }

    private handleError() {
        return (response: Response) => {
            if (response.status === 401) {
                if(localStorage.getItem(environment.authKey) != null)
                {
                    //TODO: check token not expired -> login
                    this.router.navigate(['notauthorized']);
                }
                else
                {
                    this.router.navigate(['login']);
                }
            }

            return Observable.throw(response);
        };
    }
}