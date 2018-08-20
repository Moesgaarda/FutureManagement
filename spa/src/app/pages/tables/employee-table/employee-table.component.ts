import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { UserService } from '../../../_services/user.service';
import { User } from '../../../_models/User';
import { environment } from '../../../../environments/environment';
import { SmartTableService } from '../../../@core/data/smart-table.service';
import * as _ from 'underscore';

@Component({
  selector: 'ngx-employee-table',
  templateUrl: './employee-table.component.html',
  styles: [`
    nb-card {
      transform: translate3d(0, 0, 0);
    }
  `],
})
export class EmployeeTableComponent {
  settings = {
    add: {
      addButtonContent: 'Tilføj ny',
    },
    edit: {
      editButtonContent: '<i class="nb-edit"></i>',
      saveButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
    },
    delete: {
      deleteButtonContent: '<i class="nb-trash"></i>',
      confirmDelete: true,
    },
    columns: {
      id: {
        title: 'ID',
        type: 'number',
      },
      firstName: {
        title: 'Fornavn',
        type: 'string',
      },
      lastName: {
        title: 'Efternavn',
        type: 'string',
      },
      username: {
        title: 'Brugernavn',
        type: 'string',
      },
      email: {
        title: 'E-mail',
        type: 'string',
      },
    },
  };
  source: LocalDataSource;
  users: User[];
  baseUrl = environment.spaUrl;

  constructor(private service: SmartTableService, private userService: UserService) {
    this.source = new LocalDataSource();
    this.loadItems();
  }

  async loadItems() {
    await this.userService.getActiveUsers().subscribe(users => {
      this.users = users;
      this.source.load(users);
      this.source.refresh;
    });
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Er du sikker på at du vil slette denne forekomst?')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

  deleteUser(userToDelete): void {
    if (window.confirm('Er du sikker på at du vil slette denne bruger?')) {
      this.userService.deleteUser(userToDelete.data.id).subscribe(() => {
        this.users.splice(_.findIndex(this.users, {id: userToDelete.data.id}), 1);
        this.source.refresh();
      });
    }
  }
}
