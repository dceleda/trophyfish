import { Injectable, EventEmitter } from "@angular/core";
import { Http, Headers, Response, RequestOptions, RequestMethod } from "@angular/http";
import { Router } from '@angular/router';

import { Observable } from "rxjs/Observable";

import { environment } from '../../environments/environment';
import { Token } from "../Model/Token";

@Injectable()
export class AuthService {

    constructor(private http: Http, private router: Router) {
    }

    postLogin(username: string, password: string): Observable<Token> {
        var url = environment.apiURL + "/connect/token";

        var data = {
            username: username,
            password: password,
            grant_type: "password",
            // space-separated list of scopes for which the token is issued
            scope: "offline_access openid roles"
        };

        let result = this.http.post(
            url,
            this.toUrlEncodedString(data),
            new RequestOptions({
                headers: new Headers({
                    "Content-Type": "application/x-www-form-urlencoded"
                })
            }))
            .map(response => {
                return this.mapTokenResponse(response);
            });

        return result;
    }

    postRefreshToken(): Observable<Token> {
        var url = environment.apiURL + "/connect/token";

        let token = this.getTokenFromStorage();

        if (token != null) {
            var data = {
                grant_type: "refresh_token",
                scope: "offline_access",
                refresh_token: token.refresh_token
            };

            return this.http.post(
                url,
                this.toUrlEncodedString(data),
                new RequestOptions({
                    headers: new Headers({
                        "Content-Type": "application/x-www-form-urlencoded"
                    })
                }))
                .map(response => {
                    return this.mapTokenResponse(response);
                });
        }

        return Observable.throw("No refresh token in the store !");
    }

    postLogout(): boolean {
        var url = environment.apiURL + "/connect/logoff";
        let opts = new RequestOptions({
            headers: new Headers({
                "Content-Type": "application/x-www-form-urlencoded"
            })
        });

        this.configureAuth(opts);

        this.http.post(url, null, )
            .catch(err => this.handleError(err))
            .subscribe();

        this.setAuth(null);

        return true;
    }

    get(url, opts: RequestOptions = new RequestOptions()) {
        opts.method = RequestMethod.Get;

        return this.request(url, opts);
    }

    post(url, data, opts: RequestOptions) {
        opts.method = RequestMethod.Post;
        opts.body = data;

        return this.request(url, opts);
    }

    put(url, data, opts: RequestOptions) {
        opts.method = RequestMethod.Put;
        opts.body = data;

        return this.request(url, opts);
    }

    delete(url, opts: RequestOptions) {
        opts.method = RequestMethod.Delete;

        return this.request(url, opts);
    }

    private request(url, opts: RequestOptions) {
        this.configureAuth(opts);
        return this.http.request(url, opts).catch(err => this.checkTokenExpiration(url, err, opts));
    }

    // Converts a Json object to urlencoded format
    private toUrlEncodedString(data: any) {
        var body = "";
        for (var key in data) {
            if (body.length) {
                body += "&";
            }
            body += key + "=";
            body += encodeURIComponent(data[key]);
        }
        return body;
    }

    // Returns TRUE if the user is logged in, FALSE otherwise.
    isLoggedIn(): boolean {
        return localStorage.getItem(environment.authKey) != null;
    }

    // Persist auth into localStorage or removes it if a NULL argument is given
    private setAuth(auth: Token): boolean {
        if (auth) {
            localStorage.setItem(environment.authKey, JSON.stringify(auth));
        }
        else {
            localStorage.removeItem(environment.authKey);
        }
        return true;
    }


    private configureAuth(opts: RequestOptions) {
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

    private mapTokenResponse(resp: Response): Token {
        let authToken: Token = resp.json();
        authToken.expiringDate = new Date(new Date().getTime() + authToken.expires_in * 1000);

        console.log(authToken);

        this.setAuth(authToken);

        return authToken;
    }

    private getRequestOptions() {
        return new RequestOptions({
            headers: new Headers({
                "Content-Type": "application/json"
            })
        });
    }

    // Retrieves the auth JSON object (or NULL if none)
    public getTokenFromStorage(): Token {
        var item = localStorage.getItem(environment.authKey);
        if (item) {
            let token: Token = JSON.parse(item);
            token.expiringDate = new Date(token.expiringDate);

            return token;
        }
        else {
            return null;
        }
    }

    private checkTokenExpiration(url, response: Response, opts: RequestOptions) {
        if (response.status === 401) {
            let token = this.getTokenFromStorage();

            if (token != null) {
                if (token.expiringDate < new Date()) {
                    return this.postRefreshToken().flatMap(token => {
                        this.configureAuth(opts);
                        return this.http.request(url, opts).catch(err => this.handleError(err));
                    })
                        .catch(err => this.handleError(err));
                }
            }
        }

        return this.handleError(response);
    }

    private handleError(error: any) {
        if (error.status === 401) {
            let token = this.getTokenFromStorage();

            if (token != null) {

                this.router.navigate(['notauthorized']);
            }
            else {
                this.router.navigate(['login']);
            }
        }
        else if (error.status === 400) {
            this.setAuth(null);
            this.router.navigate(['login']);
        }

        return Observable.throw(error);
    }
}
