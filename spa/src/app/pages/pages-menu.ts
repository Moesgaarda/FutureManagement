import { NbMenuItem } from '@nebular/theme';

export const MENU_ITEMS: NbMenuItem[] = [
  {
    title: 'Forside',
    icon: 'fa fa-home',
    link: '/pages/dashboard',
    home: true,
  },
  {
    title: 'Projekter',
    icon: 'fa fa-th',
    children: [
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
        title: 'Lagerbeholdning',
        link: '/pages/tables/active-item-table',
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
        title: 'Ansatte',
        link: '/pages/tables/employee-table',
      },
    ],
  },
  {
    title: 'Midlertigig loginside', // menu title
    icon: 'fa fa-unlock', // menu icon
    link: '/pages/new',
  },
];
