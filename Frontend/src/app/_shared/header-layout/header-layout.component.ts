import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_services/account.service';
import { CartServiceService } from 'src/app/_services/cart-service.service';

@Component({
  selector: 'app-header-layout',
  templateUrl: './header-layout.component.html',
  styleUrls: ['./header-layout.component.css'],
})
export class HeaderLayoutComponent implements OnInit {
  userModel: any = {};
  windowWidth: number;
  constructor(
    public accountService: AccountService,
    private router: Router,
    private cartService: CartServiceService
  ) {
    this.windowWidth = window.innerWidth;
  }

  amount: number = 0;
  ngOnInit() {
    this.loadCart();
  }

  login() {
    this.accountService.login(this.userModel).subscribe({
      next: (_) => this.router.navigateByUrl('/members'),
    });
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
  @HostListener('window:resize', ['$event'])
  onResize(event: Event): void {
    this.windowWidth = window.innerWidth;
  }
  goToCheckout() {
    this.router.navigateByUrl('/checkout');
  }
  loadCart() {
    if (!localStorage.getItem('user')) {
      return;
    }
    this.cartService.getCart().subscribe({
      next: (cart) => {
        if (cart && cart.id !== 0) {
          this.amount += cart.shoes.length;
        }
      },
    });
  }
}
