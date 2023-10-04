import { NewPhoto } from './newPhotos';
import { NewSize } from './newSizes';

export interface AddShoes {
  name: string;
  price: number;
  brand: string;
  isForMan: boolean;
  amount: number;
  available: number;
  photos: NewPhoto[];
  sizes: NewSize[];
}
