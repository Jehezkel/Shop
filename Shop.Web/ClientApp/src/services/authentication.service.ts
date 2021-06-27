import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject, Observable } from "rxjs";
import { map } from "rxjs/operators";
import {
  AccountClient,
  AppUser,
  LogInCommand,
  LogInResponse,
  RegisterCommand,
} from "./appweb-api-client";

// export enum Role {
//   User = "User",
//   Admin = "Admin",
// }
// export class User {
//   username: string;
//   token: string;
//   // role: Role;
// }

@Injectable({ providedIn: "root" })
export class AuthenticationService {
  private currentUserSubject: BehaviorSubject<LogInResponse>;
  public currentUser: Observable<LogInResponse>;
  constructor(private accountClient: AccountClient, private router: Router) {
    this.currentUserSubject = new BehaviorSubject<LogInResponse>(
      JSON.parse(localStorage.getItem("currentUser"))
    );
    this.currentUser = this.currentUserSubject.asObservable();
  }
  public get currentUserValue(): LogInResponse {
    return this.currentUserSubject.value;
  }

  login(loginCommand: LogInCommand) {
    console.log("jeeee");
    this.accountClient
      .login(loginCommand)
      //map(user=>{
      //   localStorage.setItem('currentUser', JSON.stringify(user);
      //   return user;)
      .subscribe(
        (response) => {
          console.log("jestem");
          console.log(response);
          localStorage.setItem("currentUser", JSON.stringify(response));
          this.currentUserSubject.next(response);
        },
        (error) => {
          console.log("jestem na bledzie", error);
          console.log(error);
          console.log("status" + error.status);
        }
      );
  }
  register(registerCommand: RegisterCommand) {
    console.log("register function");
    this.accountClient.register(registerCommand).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log("Error occured", error);
      }
    );
  }
  logout() {
    localStorage.removeItem("currentUser");
    this.currentUserSubject.next(null);
    this.router.navigate(["/login"]);
  }
}
