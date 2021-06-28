import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { ShoppingCartList, ShoppingCartRequest } from '../entities/shopping-cart';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {

  public cart: ShoppingCartRequest[] = []; 
   
  constructor(private http: HttpClient, @Inject('BASE_API_URL') private baseUrl: string) { }

  getShoppingCartProducts(obj: import("../entities/shopping-cart").ShoppingCartRequest[]) {
    return this.http.post<ShoppingCartList[]>(this.baseUrl + 'shoppingcart', obj);
  }

  addProduct(id: number) {
    let product = this.cart.filter(t => t.id == id);
    if(product.length == 0){
      this.cart.push({id: id, quantity: 1});
    }else{
      let index = this.cart.findIndex(t => t.id == id);
      this.cart[index].quantity++;
    }
  }

  subtractProduct(id: number) {
    let product = this.cart.filter(t => t.id == id);
    if(product.length != 0){    
      let index = this.cart.findIndex(t => t.id == id);
      this.cart[index].quantity--;
      if(this.cart[index].quantity == 0){
        this.removeProduct(id);
      }
    }
  }

  removeProduct(id: number) {
    let index = this.cart.findIndex(t => t.id == id);
    this.cart.splice(index, 1)
  }
}
