import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Shoes } from 'src/app/_models/shoes';
import { ShoesSeviceService } from 'src/app/_services/shoes-sevice.service';

@Component({
  selector: 'app-home-gender',
  templateUrl: './home-gender.component.html',
  styleUrls: ['./home-gender.component.css'],
})
export class HomeGenderComponent {
  shoes: Shoes[] = [];
  name: any;
  constructor(
    private shoesService: ShoesSeviceService,
    private route: ActivatedRoute
  ) {}
  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.name = params.get('name');
      this.loadMembes();
    });
  }
  loadMembes() {
    this.shoesService.sortByGender(this.name).subscribe({
      next: (shoes) => (this.shoes = shoes),
    });
  }
}
