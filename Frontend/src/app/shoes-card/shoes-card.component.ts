import { Component, Input } from '@angular/core';
import { Shoes } from '../_models/shoes';
import { AccountService } from '../_services/account.service';
import { ShoesSeviceService } from '../_services/shoes-sevice.service';

@Component({
  selector: 'app-shoes-card',
  templateUrl: './shoes-card.component.html',
  styleUrls: ['./shoes-card.component.css'],
})
export class ShoesCardComponent {
  @Input() shoes: Shoes | undefined;
  admin: any;
  constructor(
    public accountService: AccountService,
    private shoesService: ShoesSeviceService
  ) {}
  ngOnInit() {
    this.accountService.currentUser$.subscribe((x) => {
      if (x?.isAdmin) {
        this.admin = true;
      }
    });
  }
  delete(shoesId: number) {
    this.shoesService.delete(shoesId).subscribe({
      next: (response) => {
        window.location.reload();
      },
    });
  }
}
