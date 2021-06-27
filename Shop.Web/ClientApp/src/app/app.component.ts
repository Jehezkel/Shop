import { Component } from "@angular/core";
import { LogInResponse } from "src/services/appweb-api-client";
import { AuthenticationService } from "src/services/authentication.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent {
  user: LogInResponse;
  /**
   *
   */
  constructor(private authService: AuthenticationService) {
    
  }
  title = "app";
}
