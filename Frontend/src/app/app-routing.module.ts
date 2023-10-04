import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { ShoesDetailComponent } from './shoes-detail/shoes-detail.component';
import { NotFoundComponent } from './_errors/not-found/not-found.component';
import { ServerErrorComponent } from './_errors/server-error/server-error.component';
import { HomeBrandComponent } from './home-page/searches/home-brand/home-brand.component';
import { HomeGenderComponent } from './home-page/searches/home-gender/home-gender.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { authGuard } from './_guard/auth.guard';
import { isAdminGuard } from './_guard/is-admin.guard';
import { EditShoesComponent } from './edit-shoes/edit-shoes.component';
import { AddShoesComponent } from './add-shoes/add-shoes.component';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: 'login', component: LoginComponent },
  { path: 'shoes/:id', component: ShoesDetailComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'server-error', component: ServerErrorComponent },
  { path: 'brand/:name', component: HomeBrandComponent },
  { path: 'gender/:name', component: HomeGenderComponent },
  {
    path: 'edit-profile/:id',
    component: EditProfileComponent,
    canActivate: [authGuard],
  },
  {
    path: 'edit-shoes/:id',
    component: EditShoesComponent,
    canActivate: [isAdminGuard],
  },
  {
    path: 'add-shoes',
    component: AddShoesComponent,
    canActivate: [isAdminGuard],
  },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
