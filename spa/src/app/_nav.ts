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
    icon: 'icon-bell',
    url: '/base',
    children: [
      {
        name: 'Vis projekter',
        url: '/projects/view',
        icon: 'icon-bell',
      },
      {
        name: 'Tilføj nyt projekt',
        url: '/projects/new',
        icon: 'icon-bell'
      }
    ]
  },
  {
    name: 'Lagerhåndtering',
    icon: 'icon-bell',
    url: '/base',
    children: [
      {
        name: 'Vis lagerbeholdning',
        url: '/items/view',
        icon: 'icon-bell',
      },
      {
        name: 'Tilføj ny genstand',
        url: '/items/new',
        icon: 'icon-bell'
      },
      {
        name: 'Vis skabeloner',
        url: '/item-templates/view',
        icon: 'icon-bell'
      },
      {
        name: 'Tilføj skabelon',
        url: '/item-templates/new',
        icon: 'icon-bell'
      }
    ]
  },
  {
    name: 'Kunder',
    icon: 'icon-bell',
    url: '/base',
    children: [
      {
        name: 'Vis kunder',
        url: '/customers/view',
        icon: 'icon-bell',
      }
    ]
  },
  {
    name: 'Bestillinger',
    icon: 'icon-bell',
    url: '/base',
    children: [
      {
        name: 'Vis bestillinger',
        url: '/orders/view',
        icon: 'icon-bell',
      },
      {
        name: 'Tilføj ny bestilling',
        url: '/orders/new',
        icon: 'icon-bell'
      }
    ]
  },
  {
    name: 'Brugere',
    icon: 'icon-bell',
    url: '/base',
    children: [
      {
        name: 'Vis brugere',
        url: '/users/view',
        icon: 'icon-bell',
      },
      {
        name: 'Tilføj ny bruger',
        url: '/users/new',
        icon: 'icon-bell'
      }
    ]
  },
  {
    name: 'Log',
    icon: 'icon-bell',
    url: '/log/show'
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
    name: 'Log ind',
    url: '/login',
    icon: 'icon-cloud-download',
    class: 'mt-auto',
    variant: 'success'
  }
];
