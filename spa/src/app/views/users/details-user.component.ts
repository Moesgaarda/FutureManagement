import { Component, OnInit } from '@angular/core';
import { User } from '../../_models/User';
import { UserService } from '../../_services/user.service';
import { ActivatedRoute, Router } from '../../../../node_modules/@angular/router';
import { environment } from '../../../environments/environment';
import { AuthService } from '../../_services/auth.service';
import { AlertifyService } from '../../_services/alertify.service';


@Component({
  templateUrl: './details-user.component.html'
})
export class DetailsUserComponent implements OnInit {
  user: User;
  readyToLoad: boolean;
  baseUrl = environment.spaUrl;

  constructor(private userService: UserService, private route: ActivatedRoute,
    public authService: AuthService, private alertify: AlertifyService,
    private router: Router, ) {
   }

  ngOnInit() {
    this.loadUserOnInit();
  }

  loadUserOnInit() {
    const userId = this.route.snapshot.params['id'];
    if (userId === this.authService.getCurrentUserId()) {
      this.userService.getMyUser(+this.route.snapshot.params['id']).subscribe( user => {
        this.user = user;
      }, error => {
        this.alertify.error('Kunne ikke hente den aktuelle bruger');
      }, () => {
        this.readyToLoad = true;
      }
      );
    } else {
    this.userService.getUser(userId)
      .subscribe(user => {
        this.user = user;
      }, error => {
        this.alertify.error('Kunne ikke hente brugeren');
      }, () => {
        this.readyToLoad = true;
      }
      );
    }
  }

  goToEditPage(userId: number) {
    this.router.navigateByUrl('users/edit/' + userId);
  }
}
