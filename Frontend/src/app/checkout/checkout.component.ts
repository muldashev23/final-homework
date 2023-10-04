import { Component, OnInit } from '@angular/core';
import { Cart } from '../_models/cart';
import { CartServiceService } from '../_services/cart-service.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'],
})
export class CheckoutComponent implements OnInit {
  totalAmount = 0;
  cart: Cart | undefined;

  constructor(
    private cartService: CartServiceService,
    private toaster: ToastrService
  ) {}
  ngOnInit(): void {
    this.loadCart();
  }
  loadCart() {
    this.cartService.getCart().subscribe({
      next: (cart) => {
        this.cart = cart;
        if (this.cart && this.cart.id !== 0) {
          this.totalAmount = this.cartService.calculateTotalPrice(this.cart);
        }
      },
    });
  }
  buy() {
    this.cartService.buy().subscribe({
      next: (x) => {
        this.toaster.success("You'r order is completed");
        window.location.reload();
      },
    });
  }
}
