import { Photo } from './photo';

export interface Shoes {
  id: number;
  name: string;
  photoUrl: string;
  price: number;
  brand: string;
  photos: Photo[];
}
