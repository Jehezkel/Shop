import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { error } from "protractor";
import {
  AddToBasketCommand,
  BasketClient,
  ProductDetailsDTO,
  ProductsClient,
} from "src/services/appweb-api-client";

@Component({
  selector: "app-product-details",
  templateUrl: "./product-details.component.html",
  styleUrls: ["./product-details.component.css"],
})
export class ProductDetailsComponent implements OnInit {
  product: ProductDetailsDTO = new ProductDetailsDTO();
  _enlargedPath: string;

  constructor(
    private _route: ActivatedRoute,
    private _productsClient: ProductsClient,
    private _basketClient: BasketClient
  ) {}

  ngOnInit(): void {
    this._route.params.subscribe((params) => {
      let selectedId = params["id"];
      this._productsClient.getProductDetail(selectedId).subscribe(
        (response) => {
          this.product = response;
          console.log(this.product);
          this._enlargedPath = this.product.productImages[0].fullFilePath;
        },
        (error) => console.log(error)
      );
    });
  }

  setEnlargedImage($event) {
    this._enlargedPath = $event.target.src;
  }
  addToBasket() {
    console.log("xd");
    var xd = new AddToBasketCommand();
    xd.productID = this.product.productId;
    xd.qty = 1;
    console.log(xd);
    this._basketClient
      .addProductToBasket(<AddToBasketCommand>{
        productID: 7,
        qty: 1,
      })
      .subscribe(
        (result) => {
          console.log(result);
        },
        (error) => {
          console.log(error);
        }
      );
  }
}
