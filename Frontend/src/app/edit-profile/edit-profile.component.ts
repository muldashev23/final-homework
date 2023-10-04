import { Component } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css'],
})
export class EditProfileComponent {
  id = this.route.snapshot.paramMap.get('id');
  editForm: FormGroup = new FormGroup({});
  admin: any;
  constructor(
    private accountService: AccountService,
    private toaster: ToastrService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.accountService.currentUser$.subscribe((x) => {
      if (x?.isAdmin) {
        this.admin = true;
      }
    });
  }

  initializeForm() {
    this.editForm = new FormGroup({
      email: new FormControl('@gmail.com', Validators.email),
      username: new FormControl('', Validators.required),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(16),
      ]),
      confirmPassword: new FormControl('', [
        Validators.required,
        this.matchValues('newPassword'),
      ]),
      newPassword: new FormControl('', [
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(16),
      ]),
      role: new FormControl('', Validators.required),
    });
    this.editForm.controls['newPassword'].valueChanges.subscribe({
      next: () =>
        this.editForm.controls['confirmPassword'].updateValueAndValidity(),
    });
  }
  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control.value === control.parent?.get(matchTo)?.value
        ? null
        : { notMatching: true };
    };
  }
  edit() {
    if (this.editForm.value.role === '') {
      this.editForm.value.role = 'User';
    }

    this.accountService.edit(this.editForm.value, this.id).subscribe({
      next: () => {
        this.toaster.success('Your Profile Edited');
        this.cancel();
      },
      error: (error) => {
        this.toaster.error(error.error);
      },
    });
  }
  cancel() {
    this.router.navigateByUrl('/');
  }
}
