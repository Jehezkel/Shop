import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { AccountClient, LogInCommand } from "src/services/appweb-api-client";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { AuthenticationService } from "src/services/authentication.service";
import { first } from "rxjs/operators";
@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit {
  loginCommand: LogInCommand = new LogInCommand();
  loading = false;
  submitted = false;
  error = "";
  constructor(
    private router: Router,
    private authService: AuthenticationService
  ) {}

  ngOnInit(): void {}
  onSubmit() {
    this.authService
      .login(this.loginCommand)
      .pipe(first())
      .subscribe({
        next: () => {
          console.log("Przenosiny");
        },
        error: (error) => {
          console.log(error);
        },
      });
  }
}
