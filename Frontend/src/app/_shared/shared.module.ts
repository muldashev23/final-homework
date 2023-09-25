import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponentComponent } from './header-component/header-component.component';
import { FooterLayoutComponent } from './footer-layout/footer-layout.component';
import { MaterialModule } from '../_material/material.module';
import { AppRoutingModule } from '../app-routing.module';

@NgModule({
  declarations: [HeaderComponentComponent, FooterLayoutComponent],
  imports: [CommonModule, MaterialModule, AppRoutingModule],
  exports: [FooterLayoutComponent, HeaderComponentComponent],
})
export class SharedModule {}
