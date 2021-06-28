import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { environment } from 'src/environments/environment';
import { ShoppingCartRequest } from '../entities/shopping-cart';

import { ShoppingCartService } from './shopping-cart.service';

describe('ShoppingCartService', () => {
  let service: ShoppingCartService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule],
      providers: [ShoppingCartService, { provide: 'BASE_API_URL', useValue: environment.apiUrl }]
    });
    service = TestBed.get(ShoppingCartService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should retrieve shopping cart total price', (done) => {

    let obj: ShoppingCartRequest[] = [
      { id: 1, quantity: 5 },
      { id: 2, quantity: 1 },
    ]

    service.getCheckoutProducts(obj).subscribe(res => {
      let expectedPrice = res.map(a => a.totalPrice).reduce((a, b) => a + b);
      expect(expectedPrice).toBe(64)
      done();
    }, err => console.log(err));
  });

  it('should add a product to the cart', () => {

    for (let index = 0; index < 8; index++) {
      service.addProduct(1);
    }
    expect(service.cart[0].quantity).toBe(8);
  });

  it('should subtract the product quantity from the cart', () => {

    for (let index = 0; index < 8; index++) {
      service.addProduct(1);
    }

    for (let index = 0; index < 6; index++) {
      service.subtractProduct(1);
    }
    expect(service.cart[0].quantity).toBe(2);
  });

  it('should remove a product from the cart', () => {

    service.addProduct(1);
    service.addProduct(2);
    service.addProduct(3);
    service.removeProduct(2);
    expect(service.cart.length).toBe(2);
  });

});
