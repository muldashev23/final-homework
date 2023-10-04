import { Component } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { Shoes } from 'src/app/_models/shoes';
import { ShoesSeviceService } from 'src/app/_services/shoes-sevice.service';

@Component({
  selector: 'app-home-brand',
  templateUrl: './home-brand.component.html',
  styleUrls: ['./home-brand.component.css'],
})
export class HomeBrandComponent {
  shoes: Shoes[] = [];
  brand: any;
  constructor(
    private shoesService: ShoesSeviceService,
    private route: ActivatedRoute,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.brand = params.get('name');
      this.loadMembes();
    });
  }
  loadMembes() {
    this.shoesService.sortByBrand(this.brand).subscribe({
      next: (shoes) => (this.shoes = shoes),
    });
  }
}
