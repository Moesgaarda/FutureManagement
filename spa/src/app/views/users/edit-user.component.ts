import { Component, OnInit } from '@angular/core';
import { User } from '../../_models/User';
import { UserService } from '../../_services/user.service';
import { ActivatedRoute, Router } from '../../../../node_modules/@angular/router';
import { environment } from '../../../environments/environment.prod';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  templateUrl: './edit-user.component.html'
})
export class EditUserComponent implements OnInit {

  user: User;
  baseUrl = environment.spaUrl;
  readyToLoad = false;

  constructor(private userService: UserService, private route: ActivatedRoute, private alertify: AlertifyService, private router: Router) {
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
    this.userService.editUser(this.user).subscribe(user => {}, error => {
      this.alertify.error('Kunne ikke gennemføre ændringerne');
  }, () => {
      this.alertify.success('Ændringer gemt');
      this.router.navigate(['users/details/' + this.user.id]);
  });
  }
}
