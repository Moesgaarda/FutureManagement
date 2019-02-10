import { Component} from '@angular/core';
import * as _ from 'underscore';
import { AuthService } from '../../_services/auth.service';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';

@Component({
  templateUrl: './view-users.component.html',
})

export class ViewUsersComponent {
  baseUrl = environment.spaUrl;

  constructor(public authService: AuthService, private router: Router) {
  }

  goToDeactivatedUsers() {
    this.router.navigate(['users/deactivated-view/']);
  }
}
