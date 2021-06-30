import { Component } from "@angular/core";
import { UserDto } from "src/services/appweb-api-client";
import { AuthenticationService } from "src/services/authentication.service";

@Component({
  selector: "app-nav-menu",
  templateUrl: "./nav-menu.component.html",
  styleUrls: ["./nav-menu.component.css"],
})
export class NavMenuComponent {
  isExpanded = false;
  user: UserDto;
  /**
   *
   */
  constructor(public authService: AuthenticationService) {
    this.authService.currentUser.subscribe((x) => {
      this.user = x;
    });
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  logout() {
    this.authService.logout();
  }
}
