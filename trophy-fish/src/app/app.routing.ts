import { ModuleWithProviders} from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { HomePageComponent } from "./Components/General/home-page/home-page.component";
import { ViewFishComponent } from "./Components/Fish/view-fish/view-fish.component";
import { AddFishComponent } from "./Components/Fish/add-fish/add-fish.component";
import { LoginComponent } from "./Components/Account/login/login.component";
import { NotAuthorizedComponent } from "./Components/General/not-authorized/not-authorized.component";
import { PageNotFoundComponent } from "./Components/General/page-not-found/page-not-found.component";

import {AuthGuard} from "./Services/auth.guard"

const appRoutes: Routes = [
    {
        path: "",
        component: HomePageComponent
    },
    {
        path: "home",
        redirectTo: ""
    },
    {
        path: "login",
        component: LoginComponent
    },
        {
        path: "fish/view/:id",
        component: ViewFishComponent
    },
    {
        path: "zglosokaz",
        component: AddFishComponent,
        canActivate: [AuthGuard]
    },
    {
        path: "notauthorized",
        component: NotAuthorizedComponent
    },
    {
        path: '**',
        component: PageNotFoundComponent
    }
];

export const AppRoutingProviders: any[] = [];
export const AppRouting: ModuleWithProviders = RouterModule.forRoot(appRoutes);