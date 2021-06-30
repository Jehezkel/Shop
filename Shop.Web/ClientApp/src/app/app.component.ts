import { Component } from "@angular/core";
import { AuthenticationService } from "src/services/authentication.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent {
  /**
   *
   */
  constructor(private authService: AuthenticationService) {}
  title = "app";
}
