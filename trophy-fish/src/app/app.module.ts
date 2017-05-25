import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpModule } from '@angular/http';
import { RouterModule} from "@angular/router"

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import "rxjs/Rx";

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


@NgModule({
  declarations: [
    AppComponent,
    TopNavBarComponent,
    AddFishComponent,
    LoginComponent,
    PageNotFoundComponent,
    HomePageComponent,
    ViewFishComponent
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
  providers: [AuthHttp, AuthService, FishService],
  bootstrap: [AppComponent]
})
export class AppModule { }
