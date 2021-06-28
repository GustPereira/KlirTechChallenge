import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Product } from '../entities/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  public products: Product[]; 

  constructor(private http: HttpClient, @Inject('BASE_API_URL') private baseUrl: string) {  

  }

  getProducts(){
    return this.http.get<Product[]>(this.baseUrl + 'products');
  }
}
