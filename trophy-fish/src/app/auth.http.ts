import { Injectable } from "@angular/core";
import { Http, Headers, Response, RequestOptionsArgs , RequestMethod} from "@angular/http";
import { Router } from '@angular/router';

import { Observable } from "rxjs/Observable";

import { environment } from '../environments/environment';
import { Token } from "./Model/Token";

@Injectable()
export class AuthHttp {

    constructor(private http: Http, private router: Router) {
    }

    get(url, opts:RequestOptionsArgs = {}) {
        this.configureAuth(opts);
        opts.method = RequestMethod.Get;

        return this.request(url, opts);
    }

    post(url, data, opts:RequestOptionsArgs = {}) {
        this.configureAuth(opts);
        opts.method = RequestMethod.Post;
        opts.body = data;

        return this.request(url, opts);
    }

    put(url, data, opts:RequestOptionsArgs = {}) {
        this.configureAuth(opts);
        opts.method = RequestMethod.Put;
        opts.body = data;

        return this.request(url, opts);
    }

    delete(url, opts:RequestOptionsArgs = {}) {
        this.configureAuth(opts);
        opts.method = RequestMethod.Delete;

        return this.request(url, opts);
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
    public getTokenFromStorage(): Token {
        var item = localStorage.getItem(environment.authKey);
        if (item) {
            return JSON.parse(item);
        }
        else {
            return null;
        }
    }

    private request(url, opts:RequestOptionsArgs = {})
    {
        return this.http.request(url, opts).catch(this.handleError());
    }

    private configureAuth(opts:RequestOptionsArgs) {
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

    private handleError() {
        return (response: Response) => {
            if (response.status === 401) {
                let token = this.getTokenFromStorage();

                if (token != null) {
                    if (token.expiringDate < new Date()) {
                        // this.authService.postRefreshToken();
                        response.statusText = "Refresh Token";
                    }
                    else {
                        this.router.navigate(['notauthorized']);
                    }
                }
                else {
                    this.router.navigate(['login']);
                }
            }

            return Observable.throw(response);
        };
    }
}