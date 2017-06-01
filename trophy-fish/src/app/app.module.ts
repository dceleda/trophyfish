import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpModule } from '@angular/http';
import { RouterModule} from "@angular/router"

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import "rxjs/Rx";
// import 'rxjs/add/operator/delay';
// import 'rxjs/add/operator/map';
// import 'rxjs/add/operator/mapTo';
// import 'rxjs/add/operator/merge';
// import 'rxjs/add/operator/mergeMap';
// import 'rxjs/add/operator/first';
// import 'rxjs/add/operator/catch';
// import 'rxjs/add/operator/do';
// import 'rxjs/add/operator/filter';
// import 'rxjs/add/observable/of';
// import 'rxjs/add/observable/interval';
// import 'rxjs/add/observable/throw';

import "jwt-decode";

import { AppComponent } from './app.component';
import { TopNavBarComponent } from './Components/top-nav-bar/top-nav-bar.component';
import { AddFishComponent } from './Components/add-fish/add-fish.component';
import { LoginComponent } from './Components/login/login.component';
import { PageNotFoundComponent } from './Components/page-not-found/page-not-found.component';
import { HomePageComponent } from './Components/home-page/home-page.component';
import { ViewFishComponent } from './Components/view-fish/view-fish.component';

import { AppRouting } from "./app.routing";
import { AuthHttp } from "./auth.http";

import { AuthService } from "./Services/auth.service";
import { FishService } from "./Services/fish.service";
import { AuthGuard } from "./Services/auth.guard";
import { NotAuthorizedComponent } from './Components/not-authorized/not-authorized.component';


@NgModule({
  declarations: [
    AppComponent,
    TopNavBarComponent,
    AddFishComponent,
    LoginComponent,
    PageNotFoundComponent,
    HomePageComponent,
    ViewFishComponent,
    NotAuthorizedComponent
  ],
  imports: [
    BsDropdownModule.forRoot(),
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule,
    AppRouting,
    ReactiveFormsModule
  ],
  providers: [AuthHttp, AuthService, FishService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
