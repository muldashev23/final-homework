import { Photo } from './photo';
import { Size } from './size';

export interface AddShoes {
  name: string;
  price: number;
  brand: string;
  isForMan: boolean;
  amount: number;
  available: number;
  photos: Photo[];
  sizes: Size[];
}
