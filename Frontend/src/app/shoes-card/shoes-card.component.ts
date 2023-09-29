import { Component, Input } from '@angular/core';
import { Shoes } from '../_models/shoes';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-shoes-card',
  templateUrl: './shoes-card.component.html',
  styleUrls: ['./shoes-card.component.css'],
})
export class ShoesCardComponent {
  @Input() shoes: Shoes | undefined;
  constructor(public accountService: AccountService) {}
}
