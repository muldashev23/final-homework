import { Component } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
})
export class RegistrationComponent {
  model: any = {};
  constructor(
    private accountService: AccountService,
    private toaster: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  register() {
    this.accountService.register(this.model).subscribe({
      next: () => {
        this.cancel();
      },
      error: (error) => {
        this.toaster.error(error.error);
        console.log(error);
      },
    });
  }
  cancel() {
    this.router.navigateByUrl('/');
  }
}
