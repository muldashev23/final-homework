import { Component } from '@angular/core';
import { ShoesSeviceService } from '../_services/shoes-sevice.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NewPhoto } from '../_models/newPhotos';
import { NewSize } from '../_models/newSizes';

@Component({
  selector: 'app-add-shoes',
  templateUrl: './add-shoes.component.html',
  styleUrls: ['./add-shoes.component.css'],
})
export class AddShoesComponent {
  addForm: FormGroup = new FormGroup({});
  photosForm: FormGroup = new FormGroup({});
  sizeForm: FormGroup = new FormGroup({});
  photosArr: NewPhoto[] = [];
  sizeArr: NewSize[] = [];
  constructor(
    private shoesService: ShoesSeviceService,
    private toaster: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.addForm = new FormGroup({
      name: new FormControl('asd', Validators.required),
      brand: new FormControl('', Validators.required),
      price: new FormControl('', Validators.required),
      amount: new FormControl('', Validators.required),
      isForMan: new FormControl('', Validators.required),
    });
    this.photosForm = new FormGroup({
      url: new FormControl('', Validators.required),
      isMain: new FormControl('', Validators.required),
    });
    this.sizeForm = new FormGroup({
      sizeNum: new FormControl('', Validators.required),
      amount: new FormControl('', Validators.required),
    });
  }

  addShoes() {
    if (this.sizeArr.length < 1 || this.photosArr.length < 1) {
      this.toaster.error('Please add Sizes and Photos');
      return;
    }
    this.shoesService
      .addNewShoes(this.addForm.value, this.sizeArr, this.photosArr)
      .subscribe({
        next: (x) => {
          this.toaster.success('Shoes Added');
          this.router.navigateByUrl('/');
        },
      });
  }
  addPhotos() {
    this.photosArr.push(this.photosForm.value);
    this.photosForm.reset();
    this.toaster.info('Photo added');
  }
  addSizes() {
    this.sizeArr.push(this.sizeForm.value);
    this.sizeForm.reset();
    this.toaster.info('Size added');
  }
  cancel() {
    this.router.navigateByUrl('/');
  }
}
