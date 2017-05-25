import { ModuleWithProviders} from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { HomePageComponent } from "./Components/home-page/home-page.component";
import { AddFishComponent } from "./Components/add-fish/add-fish.component";
import { LoginComponent } from "./Components/login/login.component";
import { PageNotFoundComponent } from "./Components/page-not-found/page-not-found.component";

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
        path: "zglosokaz",
        component: AddFishComponent
    },
    {
        path: '**',
        component: PageNotFoundComponent
    }
];

export const AppRoutingProviders: any[] = [];
export const AppRouting: ModuleWithProviders = RouterModule.forRoot(appRoutes);