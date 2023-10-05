import { Component, OnInit } from '@angular/core';
import { Shoes } from '../_models/shoes';
import { CommonModule, NgFor } from '@angular/common';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { GalleryItem, GalleryModule, ImageItem } from 'ng-gallery';
import { ActivatedRoute, Router } from '@angular/router';
import { ShoesSeviceService } from '../_services/shoes-sevice.service';
import {
  FormBuilder,
  FormsModule,
  ReactiveFormsModule,
  NgForm,
} from '@angular/forms';
import { CartServiceService } from '../_services/cart-service.service';
import { Cart } from '../_models/cart';
import { Size } from '../_models/size';

@Component({
  selector: 'app-shoes-detail',
  standalone: true,
  imports: [
    NgFor,
    CommonModule,
    TabsModule,
    GalleryModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  templateUrl: './shoes-detail.component.html',
  styleUrls: ['./shoes-detail.component.css'],
})
export class ShoesDetailComponent implements OnInit {
  shoes: Shoes | undefined;
  images: GalleryItem[] = [];
  sizeId: number = 0;
  cart: Cart | undefined;
  totalAmount = 0;

  constructor(
    private shoesService: ShoesSeviceService,
    private route: ActivatedRoute,
    private cartService: CartServiceService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadShoes();
    this.loadCart();
  }
  loadShoes() {
    let id = this.route.snapshot.paramMap.get('id');
    if (!id) return;
    this.shoesService.getOneShoes(id).subscribe({
      next: (shoes) => {
        (this.shoes = shoes), this.getImages();
      },
    });
  }

  getImages() {
    if (!this.shoes) return;
    for (const photo of this.shoes.photos) {
      this.images.push(new ImageItem({ src: photo.url, thumb: photo.url }));
    }
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
  onSubmit() {
    console.log(this.sizeId);
    let sizeToBuy: Size;
    this.shoes?.sizes.forEach((x) => {
      if (x.id === this.sizeId) {
        sizeToBuy = x;
        this.cartService.addToCart(sizeToBuy, `${this.shoes?.id}`).subscribe({
          next: (size) => {},
        });
      }
    });
    setTimeout(() => {
      window.location.reload();
    }, 1000);
  }
  checkout() {
    this.router.navigateByUrl('/checkout');
  }
}
