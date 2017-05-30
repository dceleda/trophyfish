import { Injectable, EventEmitter } from "@angular/core";
import { Http, Headers, Response, RequestOptions } from "@angular/http";
import { Observable } from "rxjs/Observable";

import { AuthHttp } from "../auth.http";

import { environment } from '../../environments/environment';

@Injectable()
export class AuthService {

    constructor(private http: AuthHttp) {
    }

    login(username: string, password: string): any {
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
                var auth = response.json();
                console.log("The following auth JSON object has been received:");
                console.log(auth);
                this.http.setAuth(auth);
                return auth;
            });

        this.delayRefresh();

        return result;
    }

    logout(): boolean {
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



    // Retrieves the auth JSON object (or NULL if none)
    getAuth(): any {
        var i = localStorage.getItem(environment.authKey);
        if (i) {
            return JSON.parse(i);
        }
        else {
            return null;
        }
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

    private delayRefresh() {
        let test = Observable.timer(7000);

        test.subscribe(val => this.refreshToken(val));
    }

    refreshToken(data) {
        alert(`${data} BAM !`);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error || "Server error");
    }
}
