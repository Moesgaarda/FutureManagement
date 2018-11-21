import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, CanActivateChild } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';


@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate, CanActivateChild {

  constructor(private authService: AuthService, private router: Router,
              private alertify: AlertifyService) {}

  canActivate(next: ActivatedRouteSnapshot): boolean {
    console.log(this.authService.test);
    if (this.authService.loggedIn()) {
      return true;
    }

    this.alertify.error('Adgang nægtet: Ikke logget ind.');
    this.router.navigate(['./login']);
    return false;
  }

  canActivateChild(next: ActivatedRouteSnapshot): boolean {
    console.log(this.authService.test);
  //   const roles = next.firstChild.data['roles'] as Array<string>;
  //   if (roles) {
  //     const match = this.authService.roleMatch(roles);
  //     if (match) {
  //       return true;
  //     } else {
  //       this.router.navigate(['./login']);
  //       this.alertify.error('Du har ikke adgang til denne side');
  //     }
  //   }
  // }
  return true;
}
