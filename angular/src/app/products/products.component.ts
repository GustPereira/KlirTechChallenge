import { Component, OnInit } from '@angular/core';
import { Product } from '../entities/product';
import { ProductsService } from '../services/products.service';
import { ShoppingCartService } from '../services/shopping-cart.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  public products: Product[];

  constructor(private productsService: ProductsService, private shoppingCarService: ShoppingCartService) { }

  ngOnInit() {
    this.productsService.getProducts().subscribe(
      res => {
        this.products = res;
      },
      err => {
        console.log(err)
      });
  }

  addProduct(id: number){
    this.shoppingCarService.addProduct(id);
  }

}
