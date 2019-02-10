import { Component, OnInit } from '@angular/core';
import { User } from '../../_models/User';
import { UserService } from '../../_services/user.service';
import { ActivatedRoute, Router } from '../../../../node_modules/@angular/router';
import { environment } from '../../../environments/environment.prod';
import { AlertifyService } from '../../_services/alertify.service';
import { AuthService } from '../../_services/auth.service';
import { userInfo } from 'os';

@Component({
  templateUrl: './edit-user.component.html'
})
export class EditUserComponent implements OnInit {

  user: User;
  baseUrl = environment.spaUrl;
  readyToLoad = false;

  constructor(private userService: UserService, private route: ActivatedRoute, private alertify: AlertifyService,
    private router: Router, private authService: AuthService) {
  }

  ngOnInit() {
    this.loadUserOnInit();
  }

  loadUserOnInit() {
    this.userService.getUser(+this.route.snapshot.params['id'])
      .subscribe(user => {
        this.user = user;
        this.readyToLoad = true;
      });
  }

  editUser() {
    this.userService.editUser(this.user).subscribe(user => {
    }, error => {
      this.alertify.error('Kunne ikke gennemføre ændringerne');
    }, () => {
      this.alertify.success('Ændringer gemt');
      this.router.navigate(['users/details/' + this.user.id]);
      const currentUserId = +this.authService.getCurrentUserId();
      if (this.user.id === currentUserId) {
        this.authService.updateToken(currentUserId).subscribe();
      }
    });
  }

  deactivateUser() {
    this.userService.deActivateUser(this.user.id).subscribe(i => {},
      error => {
        this.alertify.error('Kunne ikke deaktivere brugeren');
      },
      () => {
        this.alertify.success('Brugeren blev deaktiveret');
      });
  }
  activateUser() {
    this.userService.activateUser(this.user.id).subscribe(i => {},
      error => {
        this.alertify.error('Kunne ikke aktivere brugeren');
      },
      () => {
        this.alertify.success('Brugeren blev aktiveret');
      });
  }
}
