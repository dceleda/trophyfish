import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";

import { Observable, Observer } from "rxjs/Rx";
// import 'rxjs/add/operator/of';


@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  private emitter:Observer<boolean>; 

  ngOnInit() {
  }

  onRxClick() {
    this.delayRefresh(3000);
  }

  onRx2Click() {
    if(this.emitter != null)
    {
      this.emitter.next(true);
    }
  }

  private delayRefresh(interval:number) {

    let test = Observable.timer(interval);

    test.takeUntil(Observable.create(e => this.emitter = e)).subscribe(val => this.testMet());



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

  private testMet() {
    alert("aaa");
  }
}
