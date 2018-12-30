import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth.service';
import { User } from '../../_models/User';

@Component({
  selector: 'app-custom-sidebar',
  templateUrl: './custom-sidebar.component.html'
})
export class CustomSidebarComponent implements OnInit {
  currentUser: User;
  changes: MutationObserver;
  sidebarMinimized: boolean;

  navItems = [
    {
      title: true,
      name: 'Navigation'
    },
    {
      name: 'Forside',
      url: '/dashboard',
      icon: 'icon-home',
    },
    {
      name: 'Projekter',
      icon: 'fa fa-folder-o',
      url: '/projects',
      children: [
        {
          name: 'Vis projekter',
          url: '/projects/view',
          icon: 'fa fa-folder-o',
          role: 'Project_View'
        },
        {
          name: 'Tilføj nyt projekt',
          url: '/projects/new',
          icon: 'fa fa-folder-o',
          role: 'Project_Add'
        }
      ]
    },
    {
      name: 'Lagerhåndtering',
      icon: 'fa fa-barcode',
      url: '/base',
      children: [
        {
          name: 'Vis lagerbeholdning',
          url: '/items/view',
          icon: 'fa fa-barcode',
          role: 'Items_View'
        },
        {
          name: 'Tilføj ny genstand',
          url: '/items/new',
          icon: 'fa fa-barcode',
          role: 'Items_Add'
        },
        {
          name: 'Vis skabeloner',
          url: '/itemTemplates/view',
          icon: 'fa fa-barcode',
          role: 'ItemTemplates_View'
        },
        {
          name: 'Tilføj skabelon',
          url: '/itemTemplates/new',
          icon: 'fa fa-barcode',
          role: 'ItemTemplates_Add'
        }
      ]
    },
    {
      name: 'Kunder',
      icon: 'fa fa-child',
      url: '/customers',
      children: [
        {
          name: 'Vis kunder',
          url: '/customers/view',
          icon: 'fa fa-child',
          role: 'Customer_View'
        }
      ]
    },
    {
      name: 'Bestillinger',
      icon: 'fa fa-envelope-o',
      url: '/orders',
      children: [
        {
          name: 'Vis bestillinger',
          url: '/orders/view',
          icon: 'fa fa-envelope-o',
          role: 'Order_View'
        },
        {
          name: 'Tilføj ny bestilling',
          url: '/orders/new',
          icon: 'fa fa-envelope-o',
          role: 'Order_Add'
        }
      ]
    },
    {
      name: 'Brugere',
      icon: 'fa fa-user-o',
      url: '/base',
      children: [
        {
          name: 'Min bruger',
          url: '/users/details/' + this.authService.getCurrentUserId(),
          icon: 'fa fa-user-o',
        },
        {
          name: 'Vis brugere',
          url: '/users/view',
          icon: 'fa fa-user-o',
          role: 'User_View'
        },
        {
          name: 'Tilføj ny bruger',
          url: '/users/new',
          icon: 'fa fa-user-o',
          role: 'User_Add'
        },
        {
          name: 'Tilføj ny rolle',
          url: '/userRoles/new',
          icon: 'fa fa-user-o',
          role: 'User_Add'
        }
      ]
    },
    {
      name: 'Log',
      icon: 'fa fa-sticky-note-o',
      url: '/logs/view',
      role: 'EventLogs_View'
    },
    {
      divider: true
    }
  ];

  ngOnInit() {
    this.currentUser = this.authService.getCurrentUser();
    this.navItems.forEach(navItem => {
      if (navItem.children) {
        navItem.children.forEach(child => {
          if (!this.authService.roleMatch([child.role])) {
            const index = navItem.children.indexOf(child, 0);
            if (index > -1) {
              navItem.children.splice(index, 1);
            }
          }
        });
      }

    });
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
