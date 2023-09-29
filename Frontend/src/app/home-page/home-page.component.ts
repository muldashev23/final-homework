import { Component } from '@angular/core';
import { Shoes } from '../_models/shoes';
import { ShoesSeviceService } from '../_services/shoes-sevice.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent {
  shoes: Shoes[] = [];
  constructor(private shoesService: ShoesSeviceService) {}
  ngOnInit(): void {
    this.loadMembes();
  }
  loadMembes() {
    this.shoesService.getAllShoes().subscribe({
      next: (shoes) => (this.shoes = shoes),
    });
  }
}
