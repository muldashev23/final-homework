import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderLayoutComponent } from './header-layout/header-layout.component';
import { FooterLayoutComponent } from './footer-layout/footer-layout.component';
import { AppRoutingModule } from '../app-routing.module';

@NgModule({
  declarations: [HeaderLayoutComponent, FooterLayoutComponent],
  imports: [CommonModule, AppRoutingModule],
  exports: [HeaderLayoutComponent, FooterLayoutComponent],
})
export class SharedModule {}
