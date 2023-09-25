import { Component, HostListener } from '@angular/core';

@Component({
  selector: 'app-header-component',
  templateUrl: './header-component.component.html',
  styleUrls: ['./header-component.component.css'],
})
export class HeaderComponentComponent {
  isScrolled = false;

  @HostListener('window:scroll', [])
  onWindowScroll() {
    // Check the scroll position and toggle the "scrolled" class accordingly
    this.isScrolled = window.scrollY > 50;
  }
}
