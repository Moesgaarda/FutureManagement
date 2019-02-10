import { Component } from '@angular/core';
import { environment } from '../../../environments/environment';
import { AuthService } from '../../_services/auth.service';
import { Router } from '@angular/router';


@Component({
  templateUrl: './view-deactivated-users.component.html',
})

export class ViewDeactivatedUsersComponent {
  baseUrl = environment.spaUrl;

  constructor(public authService: AuthService, private router: Router) {
  }

  goToActivatedUsers() {
    this.router.navigate(['users/view/']);
  }
}
