import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';


@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(): boolean {
    if (this.authService.loggedIn()) {
      return true;
    }

    console.log('Not logged in - NO ACCESS');
    this.router.navigate(['views/login']);
    return false;
  }
}
