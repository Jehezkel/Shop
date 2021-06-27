import { Component, OnInit } from "@angular/core";
import { RegisterCommand } from "src/services/appweb-api-client";
import { AuthenticationService } from "src/services/authentication.service";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.css"],
})
export class RegisterComponent implements OnInit {
  registerCommand: RegisterCommand = new RegisterCommand();
  constructor(private authService: AuthenticationService) {}

  ngOnInit(): void {}
  onSubmit(): void {
    console.log("submitted");
    console.log(this.registerCommand);
    this.authService.register(this.registerCommand);
  }
}
