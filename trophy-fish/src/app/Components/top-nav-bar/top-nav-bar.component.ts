import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";

import { AuthService } from "../../Services/auth.service";

@Component({
  selector: 'app-top-nav-bar',
  templateUrl: './top-nav-bar.component.html',
  styleUrls: ['./top-nav-bar.component.css']
})
export class TopNavBarComponent implements OnInit {

  isActive(data: any[]): boolean {
    return this.router.isActive(this.router.createUrlTree(data), true);
  }

  constructor(public router: Router, private authService: AuthService) { }

  ngOnInit() {
  }

  logout(): boolean {
    if (this.authService.postLogout()) {
      this.router.navigate([""]);
    }

    return false;
  }
}
