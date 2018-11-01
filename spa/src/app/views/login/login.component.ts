import { Component } from '@angular/core';
import { AuthService } from '../../_services/auth.service';
import { Router } from '@angular/router';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: 'login.component.html'
})
export class LoginComponent {

  model: any = {};
  registerMode = false;

  constructor(public authService: AuthService, private router: Router, private alertify: AlertifyService) {}

  login() {
    this.authService.login(this.model).subscribe(data => {
      this.alertify.success('Logged ind');
    }, error => {
      this.alertify.error('Kunne ikke logge ind');
    }, () => {
      this.router.navigate(['']);
    });
  }

  logout() {
    this.authService.userToken = null;
    localStorage.removeItem('token');
    this.alertify.message('logged ud');
    this.router.navigate(['login']);
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  toggleRegisterPage() {
    this.router.navigate(['register']);
  }

  returnToDashboard() {
    this.router.navigate(['']);
  }
}
