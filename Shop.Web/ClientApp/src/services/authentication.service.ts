import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { AccountClient, LogInCommand } from "./appweb-api-client";

export enum Role {
  User = "User",
  Admin = "Admin",
}
export class User {
  username: string;
  token: string;
  role: Role;
}

@Injectable({ providedIn: "root" })
export class AuthenticationService {
  private currentUserSubject: BehaviorSubject<User>;
  private currentUser: Observable<User>;
  constructor(private accountClient: AccountClient) {
    this.currentUserSubject = new BehaviorSubject<User>(
      JSON.parse(localStorage.getItem("currentUser"))
    );
    this.currentUser = this.currentUserSubject.asObservable();
  }
  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  login(loginCommand: LogInCommand) {
    console.log("jeeee");
    this.accountClient.login(loginCommand).subscribe(
      (response) => {
        console.log("jestem");
        console.log(response);
      },
      (error) => {
        console.log("jestem na bledzie");
        console.log(error);
        console.log("status" + error.status);
      }
    );
  }
}
