import { Component, EventEmitter } from '@angular/core';
import { AuthService } from '../../_services/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: 'register.component.html'
})
export class RegisterComponent {

  model: any = {};

  constructor(private authService: AuthService) { }

  register() {
    this.authService.register(this.model).subscribe(() => {
      console.log('Registration succesful');
    }, error => {
      console.log(error);
    });
  }
}
