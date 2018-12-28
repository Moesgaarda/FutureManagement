import { Component } from '@angular/core';
import { environment } from '../../../environments/environment';
import { AuthService } from '../../_services/auth.service';
import { UserForRegister } from '../../_models/UserForRegister';
import { AlertifyService } from '../../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  templateUrl: './new-user.component.html'
})

export class NewUserComponent {
  baseUrl = environment.spaUrl;
  user: UserForRegister = {} as UserForRegister;
  passwordConfirm: string;
  isValid = true;

  constructor(private authService: AuthService, private alertify: AlertifyService, private router: Router) {
  }
  createUser() {
    if (this.user.name !== undefined
      && this.user.surname !== undefined
      && this.user.username !== undefined
      && this.user.password !== undefined
      && this.user.password === this.passwordConfirm) {
      this.authService.register(this.user).subscribe(() => {
        this.alertify.success('Bruger var oprettet');
        this.router.navigate(['users/view/']);
      }, error => {
        this.alertify.error('Kunne ikke tilføje bruger');
      });
    } else {
      this.alertify.error('Brugeren var ikke valid');
    }
  }
  goToUserTable() {
    this.router.navigate(['/users/view/']);
  }
}
