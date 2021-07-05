import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import {
  AddToBasketCommand,
  BasketClient,
  BasketDTO,
} from "./appweb-api-client";
import { AuthenticationService } from "./authentication.service";

@Injectable({
  providedIn: "root",
})
export class BasketService {
  public currentBasket: Observable<BasketDTO>;
  constructor(private basketClient: BasketClient) {
    this.currentBasket = basketClient.getUserBasket();
  }
  addToBasket(productId: number, qty: number) {
    console.log("Add to basket function");
    var newBasketEntry = new AddToBasketCommand({
      productID: productId,
      qty: qty,
    });
    console.log("Calling add to basket with object: ", newBasketEntry);
    this.currentBasket = this.basketClient.addProductToBasket(newBasketEntry);
  }
}
