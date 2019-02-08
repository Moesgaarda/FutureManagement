import {Pipe, PipeTransform} from '@angular/core';
import {RoleCategory} from '../_models/RoleCategory';

@Pipe({name: 'userRoleFilter'})
export class UserRoleFilterPipe implements PipeTransform {
  transform(roles: RoleCategory[], filterText: string): RoleCategory[] {
    if (!filterText) {
      return roles;
    }

    return roles.filter(role => role.name.includes(filterText));
  }
}
