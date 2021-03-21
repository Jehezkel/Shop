import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CreateProductCommand, FileParameter, ImagesClient, ProductImage, ProductsClient } from "../../services/appweb-api-client";

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {
  @Input() productId?: number
  product: CreateProductCommand = new CreateProductCommand;
  constructor(private productsClient: ProductsClient, private router: Router, private imagesClient: ImagesClient) { }
  productImages: ProductImage[]=[];

  ngOnInit(): void {
    if(this.productId){
      console.log("not implemented yet")
      this.product.productName = "Testowa Nazwa"
      this.product.price = 99.9
    }else{
      this.product.images=[];
    }
  }
  saveForm(){
    if(this.productId){
      console.log("no endpoint yet");
    }else{
      
      this.productsClient.create(this.product).subscribe(result=> {
        console.log("utworzono "+result);
        this.product=new CreateProductCommand;
        this.router.navigate(['/product-list']);
      }, error=>console.log(error))
    }
  }
  uploadFile($event){
    
    Array.from($event.target.files).forEach( (file: File) => {
      this.imagesClient.upload(<FileParameter>{
        data: file,
        fileName: file.name
      }
        ).subscribe(response=> {
          console.log(response);
          console.log(this.productImages);
          this.product.images.push(response);
        }
        ,error=> console.log("error "+error))
    })
    
    
  }


}
