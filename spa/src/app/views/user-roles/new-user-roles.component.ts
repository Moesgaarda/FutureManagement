import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../../_services/alertify.service';



@Component({
  templateUrl: './new-user-roles.component.html'
})

export class NewUserRolesComponent implements OnInit {

  constructor(private alertify: AlertifyService) {}

  userRoleTest: { id: number, name: string, hasRole: boolean, test: { id: number, name: string, hasRole: boolean }[] }[] = [
    {
      'id': 0, 'name': 'Kunder', hasRole: false, test: [
        { id: 0, name: 'Vis alle kunder', hasRole: false }, { id: 1, name: 'Opret kunde', hasRole: false },
        { id: 2, name: 'Rediger kunde', hasRole: false }
      ],
    },
    {
      'id': 1, 'name': 'Projekter', hasRole: false, test: [
        { id: 0, name: 'Vis alle projekter', hasRole: false }, { id: 1, name: 'Opret projekt', hasRole: false },
        { id: 2, name: 'Rediger projekt', hasRole: false }
      ],
    },
    {
      'id': 2, 'name': 'Bestillinger', hasRole: false, test: [
        { id: 0, name: 'Vis alle bestillinger', hasRole: false }, { id: 1, name: 'Opret bestilling', hasRole: false },
        { id: 2, name: 'Rediger bestilling', hasRole: false }
      ],
    }
  ];

  ngOnInit() {

  }


  changeHasRole(id: number) {
    if (this.userRoleTest[id].hasRole === true) {
      this.userRoleTest[id].hasRole = false;
      return false;
    } else {
      this.userRoleTest[id].hasRole = true;
      return true;
    }
  }

  changeHasSubRole(roleId: number, subRoleId: number) {
    if (this.userRoleTest[roleId].test[subRoleId].hasRole === true) {
      this.userRoleTest[roleId].test[subRoleId].hasRole = false;
      return false;
    } else {
      this.userRoleTest[roleId].test[subRoleId].hasRole = true;
      return true;
    }
  }

  addRole() {
    this.alertify.error('Kunne ikke tilføje rolle');
  }
}
