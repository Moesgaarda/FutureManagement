import { Component, OnInit } from '@angular/core';



@Component({
  templateUrl: './new-user-roles.component.html'
})

export class NewUserRolesComponent implements OnInit {

  userRoleTest: { id: number, name: string, hasRole: boolean, test: { id: number, name: string, hasRole: boolean }[] }[] = [
    {
      'id': 0, 'name': 'Available', hasRole: false, test: [
        { id: 0, name: 'hey', hasRole: false }, { id: 1, name: 'hey', hasRole: false }, { id: 2, name: 'hey', hasRole: false }
      ],
    },
    {
      'id': 0, 'name': 'Ready', hasRole: false, test: [
        { id: 0, name: 'hey', hasRole: false }, { id: 1, name: 'hey', hasRole: false }, { id: 2, name: 'hey', hasRole: false }
      ],
    },
    {
      'id': 0, 'name': 'Yo', hasRole: false, test: [
        { id: 0, name: 'hey', hasRole: false }, { id: 1, name: 'hey', hasRole: false }, { id: 2, name: 'hey', hasRole: false }
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
}
