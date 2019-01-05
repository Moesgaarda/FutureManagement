import { JwtHelperService } from '@auth0/angular-jwt';

export const navItems = [
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
          role: 'Project_View',
        },
        {
          name: 'Tilføj nyt projekt',
          url: '/projects/new',
          icon: 'fa fa-folder-o',
          role: 'Project_Add',
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
          role: 'Items_View',
        },
        {
          name: 'Tilføj ny genstand',
          url: '/items/new',
          icon: 'fa fa-barcode',
          role: 'Items_Add',
        },
        {
          name: 'Vis skabeloner',
          url: '/itemTemplates/view',
          icon: 'fa fa-barcode',
          role: 'ItemTemplates_View',
        },
        {
          name: 'Tilføj skabelon',
          url: '/itemTemplates/new',
          icon: 'fa fa-barcode',
          role: 'ItemTemplates_Add',
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
          role: 'Customer_View',
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
          role: 'Order_View',
        },
        {
          name: 'Tilføj ny bestilling',
          url: '/orders/new',
          icon: 'fa fa-envelope-o',
          role: 'Order_Add',
        }
      ]
    },
    {
      name: 'Brugere',
      icon: 'fa fa-user-o',
      url: '/base',
      children: [
        {
          name: 'Vis brugere',
          url: '/users/view',
          icon: 'fa fa-user-o',
          role: 'User_View',
        },
        {
          name: 'Tilføj ny bruger',
          url: '/users/new',
          icon: 'fa fa-user-o',
          role: 'User_Add',
        },
        {
          name: 'Tilføj ny rolle',
          url: '/userRoles/new',
          icon: 'fa fa-user-o',
          role: 'User_Add',
        }
      ]
    },
    {
      name: 'Log',
      icon: 'fa fa-sticky-note-o',
      url: '/logs/view',
      role: 'EventLogs_View',
    },
    {
      divider: true
    }
  ];
