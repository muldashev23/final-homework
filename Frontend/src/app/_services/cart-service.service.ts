import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Cart } from '../_models/cart';
import { Size } from '../_models/size';

@Injectable({
  providedIn: 'root',
})
export class CartServiceService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}
  getCart() {
    return this.http.get<Cart>(this.baseUrl + 'cart');
  }
  addToCart(sizeToBuy: Size, shoesID: string) {
    return this.http.post<Size>(
      this.baseUrl + 'cart/add/' + shoesID,
      sizeToBuy
    );
  }
  calculateTotalPrice(cart: Cart): number {
    let total = 0;
    cart.shoes.forEach((x) => {
      total += x.price;
    });

    return total;
  }
  buy() {
    return this.http.delete(this.baseUrl + 'cart');
  }
}
