import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";

import { Fish } from "../../../Model/Fish";

import { FishService } from "../../../Services/fish.service";
import { AuthService } from "../../../Services/auth.service";

@Component({
  selector: 'app-view-fish',
  templateUrl: './view-fish.component.html',
  styleUrls: ['./view-fish.component.css']
})
export class ViewFishComponent implements OnInit {

  fish: Fish;

  constructor(
    private authService: AuthService,
    private fishService: FishService,
    private router: Router,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    var id = +this.activatedRoute.snapshot.params['id'];

    if (id) {
      this.fishService.get(id).subscribe(fish => this.fish = fish);
      console.log(this.fish);
    }
    // else if (id === 0) {
    //     console.log("id is 0: switching to edit mode ...");

    //     this.router.navigate(["item/edit", 0]);
    // }
    else {
      console.log("Invalid id ...");
      this.router.navigate([""]);
    }
  }

  onInsert() {
    let fish: Fish = {
      Id : null,
      Length: 101
    }

    this.fishService.add(fish).subscribe(data => {
      this.fish = data;
      console.log("Item " + this.fish.Id + " has been added.");
      // this.router.navigate(["item/view", this.item.Id]);
    },
      error => console.log(error)
    );
  }

  getTest() {
    this.fishService.getTest().subscribe(data => {
      console.log(data);
      // this.router.navigate(["item/view", this.item.Id]);
    },
      error => console.log(error)
    );
  }

}
