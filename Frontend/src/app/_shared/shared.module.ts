import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderLayoutComponent } from './header-layout/header-layout.component';
import { AppRoutingModule } from '../app-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@NgModule({
  declarations: [HeaderLayoutComponent],
  imports: [
    CommonModule,
    AppRoutingModule,
    ToastrModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
  ],
  exports: [
    HeaderLayoutComponent,
    BsDropdownModule,
    ToastrModule,
    TabsModule,
    ReactiveFormsModule,
  ],
})
export class SharedModule {}
