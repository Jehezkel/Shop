import { Component } from "@angular/core";
import { AppUser, LogInResponse } from "src/services/appweb-api-client";
import { AuthenticationService } from "src/services/authentication.service";

@Component({
  selector: "app-nav-menu",
  templateUrl: "./nav-menu.component.html",
  styleUrls: ["./nav-menu.component.css"],
})
export class NavMenuComponent {
  isExpanded = false;
  user: LogInResponse;
  /**
   *
   */
  constructor(public authService: AuthenticationService) {
    this.user = this.authService.currentUserValue;
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
