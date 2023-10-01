import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Shoes } from '../_models/shoes';

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
}
