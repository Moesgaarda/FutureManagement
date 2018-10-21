import { Component, OnInit } from '@angular/core';
import { User } from '../../_models/User';
import { UserService } from '../../_services/user.service';
import { ActivatedRoute } from '../../../../node_modules/@angular/router';
import { environment } from '../../../environments/environment';


@Component({
  templateUrl: './details-user.component.html'
})
export class DetailsUserComponent implements OnInit {
  nameDisabled: boolean;
  userNameDisabled: boolean;
  surnameDisabled: boolean;
  emailDisabled: boolean;
  user: User;
  baseUrl = environment.spaUrl;

  constructor(private userService: UserService, private route: ActivatedRoute) {
   }

  ngOnInit() {
    this.nameDisabled = true;
    this.loadUserOnInit();
  }

  loadUserOnInit() {
    this.userService.getUser(+this.route.snapshot.params['id'])
      .subscribe(user => {
        this.user = user;
      });
  }

  goToUserTable() {
    location.href = this.baseUrl + '/users/view/';
  }
}
