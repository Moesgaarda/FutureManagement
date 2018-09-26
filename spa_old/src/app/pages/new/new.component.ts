import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth.service';
import { Router } from '@angular/router';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  selector: 'ngx-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css'],
})


export class NewComponent implements OnInit {
  model: any = {};
  registerMode = false;

  constructor(public authService: AuthService, private router: Router, private alertify: AlertifyService) {}

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(data => {
      console.log('logged in successfully');
      this.alertify.success('logged ind');
    }, error => {
      console.log('failed to login');
      this.alertify.error('Kunne ikke logge ind');
    }, () => {
      this.router.navigate(['']);
    })
  }

  logout() {
    this.authService.userToken = null;
    localStorage.removeItem('token');
    console.log('logged out');
    this.alertify.message('logged ud');
    this.router.navigate(['pages/new']);
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  registerToggle() {
    this.registerMode = true;
  }

  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }
}
