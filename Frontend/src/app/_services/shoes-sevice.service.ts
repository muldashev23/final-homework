import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Shoes } from '../_models/shoes';
import { AddShoes } from '../_models/addShoes';
import { NewSize } from '../_models/newSizes';
import { NewPhoto } from '../_models/newPhotos';

@Injectable({
  providedIn: 'root',
})
export class ShoesSeviceService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getAllShoes() {
    return this.http.get<Shoes[]>(this.baseUrl + 'shoes');
  }

  getOneShoes(id: string) {
    return this.http.get<Shoes>(this.baseUrl + 'shoes/' + id);
  }

  sortByGender(gender: string | null) {
    return this.http.get<Shoes[]>(this.baseUrl + 'shoes/gender/' + gender);
  }

  sortByBrand(name: string | null) {
    return this.http.get<Shoes[]>(this.baseUrl + 'shoes/brand/' + name);
  }
  delete(shoesId: number) {
    return this.http.delete(this.baseUrl + 'shoes/' + `${shoesId}`);
  }
  addNewShoes(shoes: AddShoes, sizes: NewSize[], photos: NewPhoto[]) {
    shoes.available = shoes.amount;
    shoes.photos = photos;
    shoes.sizes = sizes;
    console.log(shoes);

    return this.http.post(this.baseUrl + 'shoes', shoes);
  }
}
