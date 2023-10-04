import { CanActivateFn, Router } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { inject } from '@angular/core';
import { map } from 'rxjs';

export const isAdminGuard: CanActivateFn = (route, state) => {
  const accountSerice = inject(AccountService);
  const router = inject(Router);
  return accountSerice.currentUser$.pipe(
    map((user) => {
      if (user?.isAdmin) return true;
      else {
        router.navigateByUrl('not-found');
        return false;
      }
    })
  );
};
