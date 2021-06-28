import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { environment } from 'src/environments/environment';

import { ProductsService } from './products.service';

describe('ProductsService', () => {
  let service: ProductsService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule],
      providers: [ProductsService, { provide: 'BASE_API_URL', useValue: environment.apiUrl }]
    });
    service = TestBed.get(ProductsService);
  });

  it('should be created', () => {
    const service: ProductsService = TestBed.get(ProductsService);
    expect(service).toBeTruthy();
  });

  it('should retrieve products list', (done) => {
    service.getProducts().subscribe(posts => {
      expect(posts.length).toBe(4);
      done();
    });
  });
});
