import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";

import { Observable, Observer } from "rxjs/Rx";
// import 'rxjs/add/operator/delay';


@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  onClick() {
    this.delayRefresh();
  }

  private delayRefresh() {

    let test = Observable.timer(1000);

    test.subscribe(val => alert("aaa"));



    //emit one item
    let example = Observable.of(null);
    //delay output of each by an extra second
    let message = Observable.merge(
      example.mapTo('Hello'),
      example.mapTo('World!').delay(1000),
      example.mapTo('Goodbye').delay(2000),
      example.mapTo('World!').delay(3000)
    );
    //output: 'Hello'...'World!'...'Goodbye'...'World!'
    const subscribe = message.subscribe(val => console.log(val));

  }
}
