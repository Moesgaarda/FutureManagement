import { Component, OnInit } from '@angular/core';
import { User } from '../../_models/User';
import { UserService } from '../../_services/user.service';
import { ActivatedRoute } from '../../../../node_modules/@angular/router';

@Component({
  templateUrl: './details-user.component.html'
})
export class DetailsUserComponent implements OnInit {
  nameDisabled: boolean;
  userNameDisabled: boolean;
  surnameDisabled: boolean;
  emailDisabled: boolean;
  user: User;

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

  enableName() {
    if (this.nameDisabled) {
      this.nameDisabled = false;
    } else {
      // indsæt i db
      this.nameDisabled = true;
    }
  }
}
