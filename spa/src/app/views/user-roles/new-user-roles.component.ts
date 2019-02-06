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
  roleNameToAdd: string;
  userRolesToAdd: UserRole[] = [] as UserRole[];

  constructor(private alertify: AlertifyService, private userService: UserService) {}

  ngOnInit() {
    this.userService.getAllRoleCategories().subscribe(roleCategories => {
      this.roleCategories = roleCategories;
    });
    this.userService.getAllRoles().subscribe(userRoles => {
      this.userRoles = userRoles;
    });
  }

  onSwitchChange(role, event) {
    if (event.target.checked) {
      this.userRolesToAdd.push(role);
    } else {
      for (let i = 0; i < this.userRoles.length; i++) {
        if (this.userRolesToAdd[i] === role) {
          this.userRolesToAdd.splice(i, 1);
        }
      }
    }
  }

  addRole() {
    const roleCategoryToAdd = {} as RoleCategory;
    roleCategoryToAdd.name = this.roleNameToAdd;
    roleCategoryToAdd.userRoles = this.userRolesToAdd;
    // TODO lav metoden når backend til userroles virker

    this.userService.addRoleCategory(roleCategoryToAdd).subscribe(data => {
      this.alertify.success('Tilføjede rolle');
    }, error => {
      this.alertify.error('Kunne ikke tilføje rollen');
    });
  }
}
