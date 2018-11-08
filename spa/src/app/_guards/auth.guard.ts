import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';


@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router,
              private alertify: AlertifyService) {}

  canActivate(next: ActivatedRouteSnapshot): boolean {
    const roles = next.firstChild.data['roles'] as Array<string>;
    console.log('firstchild auth.guard.ts');
    console.log(next.firstChild);
    console.log('roles auth.guard.ts');
    console.log(roles);
    if (roles) {
      console.log('Role are not null');
      const match = this.authService.roleMatch(roles);
      if (match) {
        console.log('There is a match');
        return true;
      } else {
        this.router.navigate(['./login']);
        this.alertify.error('Du har ikke adgang til denne side');
      }
    } else {
      console.log('roles were null');
    }

    if (this.authService.loggedIn()) {
      return true;
    }

    this.alertify.error('Adgang nægtet: Ikke logget ind.');
    this.router.navigate(['./login']);
    return false;
  }
}
