import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { CounterComponent } from "./counter/counter.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";

import { ProductListComponent } from "./product-list/product-list.component";
import { ProductCardComponent } from "./product-list/product-card/product-card.component";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { ProductFormComponent } from "./product-form/product-form.component";
import { ProductDetailsComponent } from "./product-details/product-details.component";
import { QuillModule } from "ngx-quill";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { JwtInterceptor } from "src/helpers/jwt.interceptor";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ProductListComponent,
    ProductCardComponent,
    ProductFormComponent,
    ProductDetailsComponent,
    LoginComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "counter", component: CounterComponent },
      { path: "product-list", component: ProductListComponent },
      { path: "product-form", component: ProductFormComponent },
      {
        path: "product-details/:id",
        component: ProductDetailsComponent,
      },
      {
        path: "fetch-data",
        component: FetchDataComponent,
        // canActivate: [AuthorizeGuard],
      },
      { path: "login", component: LoginComponent },
      { path: "register", component: RegisterComponent },
    ]),
    NgbModule,
    QuillModule.forRoot(),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
