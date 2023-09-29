import { Component } from '@angular/core';
import { Shoes } from '../_models/shoes';
import { CommonModule } from '@angular/common';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { GalleryItem, GalleryModule, ImageItem } from 'ng-gallery';
import { ActivatedRoute } from '@angular/router';
import { ShoesSeviceService } from '../_services/shoes-sevice.service';

@Component({
  selector: 'app-shoes-detail',
  standalone: true,
  templateUrl: './shoes-detail.component.html',
  styleUrls: ['./shoes-detail.component.css'],
  imports: [CommonModule, TabsModule, GalleryModule],
})
export class ShoesDetailComponent {
  shoes: Shoes | undefined;
  images: GalleryItem[] = [];

  constructor(
    private shoesService: ShoesSeviceService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadShoes();
  }
  loadShoes() {
    var name = this.route.snapshot.paramMap.get('name');
    if (!name) return;
    this.shoesService.getOneShoes(name).subscribe({
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
}
