import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from './auth/auth.service';
import { map } from 'rxjs/operators';

@Injectable()
export class UserRouteGuard implements CanActivate {
  constructor(private _authService: AuthService, private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (this._authService.appUser$.pipe(map( user => user.isLoggedIn()))) {
      return true;
    }

    this.router.navigate(['/unauthorized']);
    return false;
  }
}
