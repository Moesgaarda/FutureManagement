import { tokenNotExpired } from 'angular2-jwt';

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
    url: '/base',
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
  },
  {
    name: 'CoreUI Features',
    url: '/base',
    icon: 'icon-puzzle',
    class: 'mt-auto',
    children: [
      {
        name: 'Widgets',
        url: '/widgets',
        icon: 'icon-calculator',
      },
      {
        name: 'Alerts',
        url: '/notifications/alerts',
        icon: 'icon-bell'
      },
      {
        name: 'Badges',
        url: '/notifications/badges',
        icon: 'icon-bell'
      },
      {
        name: 'Modals',
        url: '/notifications/modals',
        icon: 'icon-bell'
      },
      {
        name: 'Icons',
        url: '/icons',
        icon: 'icon-star',
      },
      {
        name: 'CoreUI Icons',
        url: '/icons/coreui-icons',
        icon: 'icon-star',
        badge: {
          variant: 'success',
          text: 'NEW'
        }
      },
      {
        name: 'Flags',
        url: '/icons/flags',
        icon: 'icon-star'
      },
      {
        name: 'Font Awesome',
        url: '/icons/font-awesome',
        icon: 'icon-star',
        badge: {
          variant: 'secondary',
          text: '4.7'
        }
      },
      {
        name: 'Simple Line Icons',
        url: '/icons/simple-line-icons',
        icon: 'icon-star'
      },
      {
        name: 'Charts',
        url: '/charts',
        icon: 'icon-pie-chart'
      },
      {
        name: 'Buttons',
        url: '/buttons/buttons',
        icon: 'icon-cursor'
      },
      {
        name: 'Dropdowns',
        url: '/buttons/dropdowns',
        icon: 'icon-cursor'
      },
      {
        name: 'Brand Buttons',
        url: '/buttons/brand-buttons',
        icon: 'icon-cursor'
      },
      {
        name: 'Cards',
        url: '/base/cards',
        icon: 'icon-puzzle'
      },
      {
        name: 'Colors',
        url: '/theme/colors',
        icon: 'icon-drop'
      },
      {
        name: 'Typography',
        url: '/theme/typography',
        icon: 'icon-pencil'
      },
      {
        name: 'Carousels',
        url: '/base/carousels',
        icon: 'icon-puzzle'
      },
      {
        name: 'Collapses',
        url: '/base/collapses',
        icon: 'icon-puzzle'
      },
      {
        name: 'Forms',
        url: '/base/forms',
        icon: 'icon-puzzle'
      },
      {
        name: 'Pagination',
        url: '/base/paginations',
        icon: 'icon-puzzle'
      },
      {
        name: 'Popovers',
        url: '/base/popovers',
        icon: 'icon-puzzle'
      },
      {
        name: 'Progress',
        url: '/base/progress',
        icon: 'icon-puzzle'
      },
      {
        name: 'Switches',
        url: '/base/switches',
        icon: 'icon-puzzle'
      },
      {
        name: 'Tables',
        url: '/base/tables',
        icon: 'icon-puzzle'
      },
      {
        name: 'Tabs',
        url: '/base/tabs',
        icon: 'icon-puzzle'
      },
      {
        name: 'Tooltips',
        url: '/base/tooltips',
        icon: 'icon-puzzle'
      }
    ]
  },
  {
    divider: true
  },
  {
    name: 'Log ud',
    url: '/login',
    icon: 'icon-login',
    class: 'mt-auto',
    variant: 'warning',
  }
];
