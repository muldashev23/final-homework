import { Component } from '@angular/core';
import { ShoesSeviceService } from '../_services/shoes-sevice.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { NewPhoto } from '../_models/newPhotos';
import { NewSize } from '../_models/newSizes';

@Component({
  selector: 'app-add-shoes',
  templateUrl: './add-shoes.component.html',
  styleUrls: ['./add-shoes.component.css'],
})
export class AddShoesComponent {
  addForm: FormGroup = new FormGroup({});
  photosForm: FormGroup = this.fb.group({});
  sizeForm: FormGroup = this.fb.group({});
  photosArr: NewPhoto[] = [];
  sizeArr: NewSize[] = [];
  constructor(
    private shoesService: ShoesSeviceService,
    private toaster: ToastrService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.addForm = new FormGroup({
      name: new FormControl('', Validators.required),
      brand: new FormControl('', Validators.required),
      price: new FormControl('', Validators.required),
      amount: new FormControl('', Validators.required),
      available: new FormControl('', Validators.required),
      isForMan: new FormControl('', Validators.required),
      photos: this.fb.array([]),
      sizes: this.fb.array([new FormControl()]),
    });
    this.photosForm = this.fb.group({
      url: new FormControl('', Validators.required),
      isMain: new FormControl('', Validators.required),
    });
    this.sizeForm = this.fb.group({
      sizeNum: new FormControl('', Validators.required),
      amount: new FormControl('', Validators.required),
    });
  }

  addShoes() {
    this.shoesService
      .addNewShoes(this.addForm.value, this.sizeArr, this.photosArr)
      .subscribe({
        next: (x) => {
          console.log(x);
        },
      });
  }
  addPhotos() {
    this.photosArr.push(this.photosForm.value);
    this.photosForm.reset();
  }
  addSizes() {
    this.sizeArr.push(this.sizeForm.value);
    this.sizeForm.reset();
  }
  cancel() {
    this.router.navigateByUrl('/');
  }
}
