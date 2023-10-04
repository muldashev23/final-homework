import { selectedSizes } from './selectedSize';
import { Shoes } from './shoes';

export interface Cart {
  id: number;
  shoes: Shoes[];
  selectedSizes: selectedSizes[];
}
