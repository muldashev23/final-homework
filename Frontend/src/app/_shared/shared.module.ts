import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderLayoutComponent } from './header-layout/header-layout.component';
import { FooterLayoutComponent } from './footer-layout/footer-layout.component';
import { AppRoutingModule } from '../app-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@NgModule({
  declarations: [HeaderLayoutComponent, FooterLayoutComponent],
  imports: [
    CommonModule,
    AppRoutingModule,
    ToastrModule.forRoot(),
    FormsModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
  ],
  exports: [
    HeaderLayoutComponent,
    FooterLayoutComponent,
    BsDropdownModule,
    ToastrModule,
    TabsModule,
  ],
})
export class SharedModule {}
