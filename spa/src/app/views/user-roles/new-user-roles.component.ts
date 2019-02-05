import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../../_services/alertify.service';
import { RoleCategory } from '../../_models/RoleCategory';
import { UserService } from '../../_services/user.service';
import { UserRole } from '../../_models/UserRole';



@Component({
  templateUrl: './new-user-roles.component.html'
})

export class NewUserRolesComponent implements OnInit {

  roleCategories: RoleCategory[] = [] as RoleCategory[];
  userRoles: UserRole[] = [] as UserRole[];
  roleCategoryToAdd: RoleCategory;

  constructor(private alertify: AlertifyService, private userService: UserService) {}

  // TODO  Skal ændres til at bruge en model når backend for userroles virker
  // dette objekt er kun til test af UI.
  /* userRoles: { id: number, name: string, hasRole: boolean, subRoles: { id: number, name: string, hasRole: boolean }[] }[] = [
    {
      'id': 0, 'name': 'Kunder', hasRole: false, subRoles: [
        { id: 0, name: 'Vis alle kunder', hasRole: false }, { id: 1, name: 'Opret kunde', hasRole: false },
        { id: 2, name: 'Rediger kunde', hasRole: false }
      ],
    },
    {
      'id': 1, 'name': 'Projekter', hasRole: false, subRoles: [
        { id: 0, name: 'Vis alle projekter', hasRole: false }, { id: 1, name: 'Opret projekt', hasRole: false },
        { id: 2, name: 'Rediger projekt', hasRole: false }
      ],
    },
    {
      'id': 2, 'name': 'Bestillinger', hasRole: false, subRoles: [
        { id: 0, name: 'Vis alle bestillinger', hasRole: false }, { id: 1, name: 'Opret bestilling', hasRole: false },
        { id: 2, name: 'Rediger bestilling', hasRole: false }
      ],
    }
  ];*/

  ngOnInit() {
    this.userService.getAllRoleCategories().subscribe(roleCategories => {
      this.roleCategories = roleCategories;
    });
    this.userService.getAllRoles().subscribe(userRoles => {
      this.userRoles = userRoles;
    });
  }

  /**
   *
   * Ændrer på bool værdien af en rolle når der clickes på en switch
   * @param {number} id
   * @memberof NewUserRolesComponent
   */
  changeHasRole(id: number) {
    /*if (this.userRoles[id].hasRole === true) {
      this.userRoles[id].hasRole = false;
    } else {
      this.userRoles[id].hasRole = true;
    }*/
  }

  /**
   *
   * Ændrer på bool værdien af en subrolle når der clickes på en switch
   * @param {number} roleId
   * @param {number} subRoleId
   * @memberof NewUserRolesComponent
   */
  changeHasSubRole(roleId: number, subRoleId: number) {
    /*if (this.userRoles[roleId].subRoles[subRoleId].hasRole === true) {
      this.userRoles[roleId].subRoles[subRoleId].hasRole = false;
    } else {
      this.userRoles[roleId].subRoles[subRoleId].hasRole = true;
    }*/
  }

  addRole() {
    // TODO lav metoden når backend til userroles virker
    this.alertify.error('Kunne ikke tilføje rolle');
    console.log(this.userRoles);
  }
}
