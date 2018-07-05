import { NbMenuItem } from '@nebular/theme';

export const MENU_ITEMS: NbMenuItem[] = [
  {
    title: 'Forside',
    icon: 'nb-home',
    link: '/pages/dashboard',
    home: true,
  },
  {
    title: 'Projekter',
    icon: 'nb-grid-b',
    link: '/pages/ui-features',
    children: [
      {
        title: 'Buttons',
        link: '/pages/ui-features/buttons',
      },
      {
        title: 'Grid',
        link: '/pages/ui-features/grid',
      },
      {
        title: 'Icons',
        link: '/pages/ui-features/icons',
      },
      {
        title: 'Modals',
        link: '/pages/ui-features/modals',
      },
      {
        title: 'Popovers',
        link: '/pages/ui-features/popovers',
      },
      {
        title: 'Typography',
        link: '/pages/ui-features/typography',
      },
      {
        title: 'Animated Searches',
        link: '/pages/ui-features/search-fields',
      },
      {
        title: 'Tabs',
        link: '/pages/ui-features/tabs',
      },
      {
        title: 'Projekter',
        link: '/pages/tables/project-table',
      },
      {
        title: 'Nyt projekt',
        link: '/pages/forms/new-project',
      },
    ],
  },
  {
    title: 'Lagerhåndtering',
    icon: 'fa fa-archive',
    children: [
      {
        title: 'Form Inputs',
        link: '/pages/forms/inputs',
      },
      {
        title: 'Form Layouts',
        link: '/pages/forms/layouts',
      },
      {
        title: 'Lagerbeholdning',
        link: '/pages/tables/item-table',
      },
      {
        title: 'Tilføj ny genstand',
        link: '/pages/forms/item',
      },
      {
        title: 'Skabeloner',
        link: '/pages/tables/item-template-table',
      },
      {
        title: 'Tilføj skabelon',
        link: '/pages/forms/item-template',
      },
    ],
  },
  {
    title: 'Kunder',
    icon: 'fa fa-user',
    children: [
      {
        title: 'Tree',
        link: '/pages/components/tree',
      }, {
        title: 'Notifications',
        link: '/pages/components/notifications',
      },
      {
        title: 'Kundetabel',
        link: '/pages/tables/customer-table',
      },
    ],
  },
  {
    title: 'Bestillinger',
    icon: 'fa fa-shopping-cart',
    children: [
      {
        title: 'Google Maps',
        link: '/pages/maps/gmaps',
      },
      {
        title: 'Leaflet Maps',
        link: '/pages/maps/leaflet',
      },
      {
        title: 'Bubble Maps',
        link: '/pages/maps/bubble',
      },
      {
        title: 'Search Maps',
        link: '/pages/maps/searchmap',
      },
    ],
  },
  {
    title: 'Brugere',
    icon: 'fa fa-id-badge',
    children: [
      {
        title: 'Echarts',
        link: '/pages/charts/echarts',
      },
      {
        title: 'Charts.js',
        link: '/pages/charts/chartjs',
      },
      {
        title: 'D3',
        link: '/pages/charts/d3',
      },
      {
        title: 'Ansatte',
        link: '/pages/tables/employee-table',
      },
    ],
  },
  {
    title: 'Editors',
    icon: 'nb-title',
    children: [
      {
        title: 'TinyMCE',
        link: '/pages/editors/tinymce',
      },
      {
        title: 'CKEditor',
        link: '/pages/editors/ckeditor',
      },
    ],
  },
  {
    title: 'Tables',
    icon: 'nb-tables',
    children: [
      {
        title: 'Smart Table',
        link: '/pages/tables/smart-table',
      },
    ],
  },
  {
    title: 'Miscellaneous',
    icon: 'nb-shuffle',
    children: [
      {
        title: '404',
        link: '/pages/miscellaneous/404',
      },
    ],
  },
  {
    title: 'Auth',
    icon: 'nb-locked',
    children: [
      {
        title: 'Login',
        link: '/auth/login',
      },
      {
        title: 'Register',
        link: '/auth/register',
      },
      {
        title: 'Request Password',
        link: '/auth/request-password',
      },
      {
        title: 'Reset Password',
        link: '/auth/reset-password',
      },
    ],
  },
  {
    title: 'New Page', // menu title
    icon: 'ion-android-home', // menu icon
    link: '/pages/new',
  },
];
