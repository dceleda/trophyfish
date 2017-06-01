import { Injectable, EventEmitter } from "@angular/core";
import { Http, Headers, Response, RequestOptions } from "@angular/http";
import { Observable } from "rxjs/Observable";

import { environment } from '../../environments/environment';
import { AuthHttp } from "../auth.http";
import { Token } from "../Model/Token";

@Injectable()
export class AuthService {

    constructor(private http: AuthHttp) {
    }

    postLogin(username: string, password: string): any {
        var url = environment.apiURL + "/connect/token";

        var data = {
            username: username,
            password: password,
            grant_type: "password",
            // space-separated list of scopes for which the token is issued
            scope: "offline_access openid roles"
        };

        var result = this.http.post(
            url,
            this.toUrlEncodedString(data),
            new RequestOptions({
                headers: new Headers({
                    "Content-Type": "application/x-www-form-urlencoded"
                })
            }))
            .map(response => {
                let auth: Token = response.json();
                console.log("The following auth JSON object has been received:");
                console.log(auth);

                this.http.setAuth(auth);
                this.delayRefresh(auth.expires_in);


                return auth;
            });

        return result;
    }

    postRefreshToken() {
        var url = environment.apiURL + "/connect/token";

        let token = this.http.getTokenFromStorage();

        if (token != null) {
            var data = {
                grant_type: "refresh_token",
                scope: "offline_access",
                refresh_token: token.refresh_token
            };

            this.http.post(
                url,
                this.toUrlEncodedString(data),
                new RequestOptions({
                    headers: new Headers({
                        "Content-Type": "application/x-www-form-urlencoded"
                    })
                }))
                .map(response => {
                    let auth: Token = response.json();
                    console.log("The following auth JSON object has been received:");
                    console.log(auth);

                    this.http.setAuth(auth);
                    this.delayRefresh(auth.expires_in);


                    return auth;
                }).subscribe();
        }
    }

    postLogout(): boolean {
        var url = environment.apiURL + "/connect/logoff";


        this.http.post(url, null, new RequestOptions({
            headers: new Headers({
                "Content-Type": "application/x-www-form-urlencoded"
            })
        }))
            .catch(err => { return this.handleError(err) })
            .subscribe();

        this.http.setAuth(null);

        return true;
    }

    // Converts a Json object to urlencoded format
    toUrlEncodedString(data: any) {
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

    private getRequestOptions() {
        return new RequestOptions({
            headers: new Headers({
                "Content-Type": "application/json"
            })
        });
    }

    private delayRefresh(expiresIn: number) {
        let test1 = Observable.timer(5000);
        test1.subscribe(val => alert("aaa"));

        let milisec = expiresIn / 2 * 1000;
        let test = Observable.timer(milisec);

        test.subscribe(val => this.postRefreshToken());
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error || "Server error");
    }
}
