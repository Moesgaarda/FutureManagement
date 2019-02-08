import {Component, OnInit} from '@angular/core';
import {User} from '../../_models/User';
import {UserService} from '../../_services/user.service';
import {ActivatedRoute} from '../../../../node_modules/@angular/router';
import {environment} from '../../../environments/environment.prod';
import {RoleCategory} from '../../_models/RoleCategory';

@Component({
  templateUrl: './edit-user.component.html'
})
export class EditUserComponent implements OnInit {
  nameDisabled: boolean;
  userNameDisabled: boolean;
  surnameDisabled: boolean;
  emailDisabled: boolean;
  roleDisabled: boolean;
  user: User;
  baseUrl = environment.spaUrl;

  constructor(private userService: UserService, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.nameDisabled = true;
    this.userNameDisabled = true;
    this.roleDisabled = true;
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

  enableUserName(save: boolean, str: string) {
    if (this.userNameDisabled) {
      this.userNameDisabled = false;
    } else {
      if (save) {
        this.user.username = str;
        this.userService.editUser(this.user).subscribe(r => {
        });
      }
      this.userNameDisabled = true;
    }
  }

  goToUserTable() {
    location.href = this.baseUrl + '/users/view/';
  }

  addUserRole(newRoleCategory: RoleCategory) {
    console.log('asdadsasd');
    // this.userService.addRole(newRoleName).subscribe(r => {});
  }
}
