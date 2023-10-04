import { Component, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-header-layout',
  templateUrl: './header-layout.component.html',
  styleUrls: ['./header-layout.component.css'],
})
export class HeaderLayoutComponent {
  userModel: any = {};
  windowWidth: number;
  constructor(public accountService: AccountService, private router: Router) {
    this.windowWidth = window.innerWidth;
  }
  ngOnInit() {}

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
}
