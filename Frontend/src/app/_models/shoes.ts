import { Photo } from './photo';
import { Size } from './size';

export interface Shoes {
  id: number;
  name: string;
  photoUrl: string;
  price: number;
  brand: string;
  isForMan: boolean;
  photos: Photo[];
  sizes: Size[];
}
