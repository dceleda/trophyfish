import { Injectable } from "@angular/core";
import { Http, Response, Headers, RequestOptions } from "@angular/http";
import { Observable } from "rxjs/Observable";

import { AuthService } from "./auth.service";
import { Fish } from "../Model/Fish"
import { environment } from '../../environments/environment';

@Injectable()
export class FishService {

  private baseUrl = environment.apiURL + "/api/fish/";

  constructor(private authService: AuthService) { }

  get(id: number): Observable<any> {
    if (id == null) {
      throw new Error("id is required.");
    }

    var url = this.baseUrl + id;

    return this.authService.get(url).map(resp => <Fish>resp.json()).catch(err => { return this.handleError(err) });
  }

  getTest(): Observable<any> {

    var url = this.baseUrl + "GetTest";

    return this.authService.get(url).catch(err => { return this.handleError(err) });
  }

  add(fish: Fish) {
    var url = this.baseUrl;

    return this.authService.post(url, JSON.stringify(fish), this.getRequestOptions())
      .map(response => response.json())
      .catch(err => { return this.handleError(err) });
  }

  // Persist auth into localStorage or removes it if a NULL argument is given
  setAuth(auth: any): boolean {
    if (auth) {
      localStorage.setItem(environment.authKey, JSON.stringify(auth));
    }
    else {
      localStorage.removeItem(environment.authKey);
    }
    return true;
  }

  private getRequestOptions():RequestOptions {
    return new RequestOptions({
      headers: new Headers({
        "Content-Type": "application/json"
      })
    });
  }

  private handleError(error: Response) {
    console.error(error);

    return Observable.throw(error || "Server error");
  }
}
