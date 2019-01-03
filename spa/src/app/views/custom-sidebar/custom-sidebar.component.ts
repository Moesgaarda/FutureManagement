import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../../_services/auth.service';
import { User } from '../../_models/User';


@Component({
  selector: 'app-custom-sidebar',
  templateUrl: './custom-sidebar.component.html'
})
export class CustomSidebarComponent implements OnInit {
  @Input() navItems = [];
  userNavItems = [];
  currentUser: User;
  readyToLoad: boolean;
  changes: MutationObserver;
  sidebarMinimized: boolean;


  ngOnInit() {
    this.addNavItems().then(() => {
      this.readyToLoad = true;
    });
  }

  async addNavItems () {
    let children = [];
    let navItemIndex = 0;
    this.navItems.forEach((navItem) => {
      if (navItem.children) {
        navItem.children.forEach((child) => {
          if (child.role) {
            if (this.authService.roleMatch([child.role])) {
              children.push(child);
            }
          } else {
            children.push(child);
          }
        });
        if (children.length !== 0) {
          this.userNavItems.push(navItem);
          this.userNavItems[navItemIndex].children = [];
          children.forEach(child => {
            this.userNavItems[navItemIndex].children.push(child);
          });
          children = [];
          navItemIndex += 1;
        }
      } else if (navItem.role) {
        if (this.authService.roleMatch([navItem.role])) {
            this.userNavItems.push(navItem);
            navItemIndex += 1;
          }
      } else {
        this.userNavItems.push(navItem);
        navItemIndex += 1;
      }
    });

    this.userNavItems.push(
      {
        name: 'Min bruger',
        url: '/users/details/' + this.authService.getCurrentUserId(),
        icon: 'fa fa-user-o',
        variant: 'success',
        class: 'mt-auto',
      }
    );
  }


  constructor(private authService: AuthService) {

    this.changes = new MutationObserver((mutations) => {
      this.sidebarMinimized = document.body.classList.contains('sidebar-minimized');
    });
  }

  logout() {
    this.authService.logout();
  }
}
