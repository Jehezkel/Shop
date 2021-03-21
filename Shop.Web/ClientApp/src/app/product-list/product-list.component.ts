import { Component, OnInit } from '@angular/core';
import { ProductsClient, ProductListDTO } from "../../services/appweb-api-client";
@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  public pListVm:  ProductListDTO;
  constructor(private _productsClient: ProductsClient) { 
    _productsClient.getProducts().subscribe(

    )
    
  }

  ngOnInit(): void {
    // this._productsClient = new ProductsClient();
    this._productsClient.getProducts().subscribe(result => {
      this.pListVm = result;
      console.log(this.pListVm);
    })
  }

}
