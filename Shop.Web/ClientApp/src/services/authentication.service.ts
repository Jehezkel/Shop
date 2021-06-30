import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject, Observable } from "rxjs";
import { first, map } from "rxjs/operators";
import {
  AccountClient,
  LogInCommand,
  RegisterCommand,
  UserDto,
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
  private currentUserSubject: BehaviorSubject<UserDto>;
  public currentUser: Observable<UserDto>;

  constructor(private accountClient: AccountClient, private router: Router) {
    this.currentUserSubject = new BehaviorSubject<UserDto>(
      JSON.parse(localStorage.getItem("currentUser"))
    );
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): UserDto {
    return this.currentUserSubject.value;
  }

  login(loginCommand: LogInCommand) {
    console.log("login function");

    return this.accountClient.login(loginCommand).pipe(
      map((user) => {
        localStorage.setItem("currentUser", JSON.stringify(user));
        this.currentUserSubject.next(user);
        return user;
      })
    );

    // .pipe(
    //   map((user) => {
    //     localStorage.setItem("currentUser", JSON.stringify(user));
    //     this.currentUserSubject.next(user);
    //     console.log(user);
    //     return user;
    //   })
    // );
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
