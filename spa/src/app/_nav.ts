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
      },
      {
        name: 'Tilføj nyt projekt',
        url: '/projects/new',
        icon: 'fa fa-folder-o'
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
      },
      {
        name: 'Tilføj ny genstand',
        url: '/items/new',
        icon: 'fa fa-barcode'
      },
      {
        name: 'Vis skabeloner',
        url: '/itemTemplates/view',
        icon: 'fa fa-barcode'
      },
      {
        name: 'Tilføj skabelon',
        url: '/itemTemplates/new',
        icon: 'fa fa-barcode'
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
      },
      {
        name: 'Tilføj ny bestilling',
        url: '/orders/new',
        icon: 'fa fa-envelope-o'
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
      },
      {
        name: 'Tilføj ny bruger',
        url: '/users/new',
        icon: 'fa fa-user-o'
      },
      {
        name: 'Tilføj ny rolle',
        url: '/userRoles/new',
        icon: 'fa fa-user-o'
      }
    ]
  },
  {
    name: 'Log',
    icon: 'fa fa-sticky-note-o',
    url: '/logs/view'
  },
  {
    divider: true
  }
];
