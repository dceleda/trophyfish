import { Injectable } from "@angular/core";
import { Http, Response, Headers, RequestOptions } from "@angular/http";
import { Observable } from "rxjs/Observable";

import { AuthHttp } from "../auth.http";

import { Fish } from "../Model/Fish"

@Injectable()
export class FishService {

  authKey = "auth";

  private baseUrl = "http://localhost:21495/api/fish/";

  constructor(private http: AuthHttp) { }

  get(id: number): Observable<any> {
    if (id == null) {
      throw new Error("id is required.");
    }

    var url = this.baseUrl + id;

    return this.http.get(url).map(resp => <Fish>resp.json()).catch(err => { return this.handleError(err) });
  }

  add(fish: Fish) {
    var url = this.baseUrl;

    return this.http.post(url, JSON.stringify(fish), this.getRequestOptions())
      .map(response => response.json())
      .catch(this.handleError);
  }

  // Persist auth into localStorage or removes it if a NULL argument is given
  setAuth(auth: any): boolean {
    if (auth) {
      localStorage.setItem(this.authKey, JSON.stringify(auth));
    }
    else {
      localStorage.removeItem(this.authKey);
    }
    return true;
  }

  private getRequestOptions() {
    return new RequestOptions({
      headers: new Headers({
        "Content-Type": "application/json"
      })
    });
  }

  private handleError(error: Response) {
    console.error(error);
    return Observable.throw(error.json().error || "Server error");
  }
}
