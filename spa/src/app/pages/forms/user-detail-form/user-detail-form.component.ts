import { Component, OnInit } from '@angular/core';
import { User } from '../../../_models/User';
import { UserService } from '../../../_services/user.service';
import { ActivatedRoute } from '../../../../../node_modules/@angular/router';

@Component({
  selector: 'ngx-user-detail-form',
  templateUrl: './user-detail-form.component.html',
  styleUrls: ['../form-inputs/form-inputs.component.scss'],
})
export class UserDetailFormComponent implements OnInit {
  nameDisabled: boolean;
  userNameDisabled: boolean;
  surnameDisabled: boolean;
  emailDisabled: boolean;
  user: User;

  constructor(private userService: UserService, private route: ActivatedRoute) {
   }

  ngOnInit() {
    this.nameDisabled = true;
    const promise = this.loadUserOnInit();
    promise.then(() => {

    });
  }

  loadUserOnInit() {
    return new Promise(resolve => {
      this.userService.getUser(+this.route.snapshot.params['id'])
      .subscribe(user => {
        this.user = user;
        resolve();
      })
    })
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
