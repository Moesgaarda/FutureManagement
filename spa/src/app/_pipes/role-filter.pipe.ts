import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'userRoleFilter'})
export class UserRoleFilterPipe implements PipeTransform {
  transform(roles: string[], filterText: string): string[] {
      if (!filterText) {
        return roles;
      }
      return roles.filter(role => role.includes(filterText));
  }
}
