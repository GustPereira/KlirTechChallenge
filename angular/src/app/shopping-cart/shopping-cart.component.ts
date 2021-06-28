import { Component, OnInit } from '@angular/core';
import { ShoppingCartList } from '../entities/shopping-cart';
import { ShoppingCartService } from '../services/shopping-cart.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  public shoppingCartProducts: ShoppingCartList[] = [];
  public totalPriceShoppingCart: number = 0;

  constructor(private shoppingCartService: ShoppingCartService) { }

  ngOnInit() {
    this.getProducts();
  }

  getProducts(){
    this.shoppingCartService.getShoppingCartProducts(this.shoppingCartService.cart).subscribe(res => {
      this.shoppingCartProducts = res
      this.totalPriceShoppingCart = res.length > 0 ? res.map(a => a.totalPrice).reduce((a, b) => a + b) : 0;
    }, err => console.log(err));
  }

  addProduct(id: number){
    this.shoppingCartService.addProduct(id);
    this.getProducts();
  }

  subtractProduct(id: number){
    this.shoppingCartService.subtractProduct(id);
    this.getProducts();
  }

}
