import { Component } from '@angular/core';
import { environment } from '../../../environments/environment';

@Component({
  templateUrl: './new-user.component.html'
})

export class NewUserComponent {
  baseUrl = environment.spaUrl;

  goToUserTable() {
    location.href = this.baseUrl + '/users/view/';
  }
}
