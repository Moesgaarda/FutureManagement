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
export class EmployeeTableComponent implements OnInit {
  settings = {
    pager: {
      perPage: 15,
    },
    mode: 'external',
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
      name: {
        title: 'Fornavn',
        type: 'string',
      },
      surname: {
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
      isActive: {
        title: 'Aktive',
        type: 'string',
      },
    },
  };
  source: LocalDataSource;
  allUsers: User[];
  activeUsers: User[];
  inactiveUsers: User[];
  baseUrl = environment.spaUrl;

  showInactive: boolean;

  constructor(private service: SmartTableService, private userService: UserService) {

  }
  async ngOnInit() {
    this.allUsers = [];
    this.showInactive = false;
    this.source = new LocalDataSource();
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getActiveUsers().subscribe(users => {
      this.activeUsers = users;
      this.allUsers = this.activeUsers;
      this.userService.getInactiveUsers().subscribe(inusers => {
        this.inactiveUsers = inusers;
        this.allUsers = this.allUsers.concat(this.inactiveUsers);
        this.source.load(this.activeUsers);
        this.source.refresh;
      });
    });
  }

  toggleInactiveUsers() {
    if (this.showInactive) {
      this.showInactive = false;
      this.source.load(this.activeUsers);
      this.source.refresh;
    } else {
      this.showInactive = true;
      this.source.load(this.allUsers);
      this.source.refresh;
    }
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
        this.allUsers.splice(_.findIndex(this.allUsers, {id: userToDelete.data.id}), 1);
        this.source.refresh();
      });
    }
  }
  deactivateUser(userToDeActivate) {
    if (window.confirm('Er du sikker på at du vil deaktivere denne bruger?')) {
      this.userService.deActivateUser(userToDeActivate.data.id).subscribe(() => {
        this.allUsers.splice(_.findIndex(this.allUsers, {id: userToDeActivate.data.id}), 1);
        this.source.refresh();
      });
    }
  }

  createUser(event): void {
    if (window.confirm('xxxxxxxxxxxxxxxxx')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }
  editUser(userToLoad): void {
    location.href = this.baseUrl + 'pages/forms/user-detail/' + userToLoad.data.id;
  }
}
  /*
  async loadActiveUsers() {
    await this.userService.getActiveUsers().subscribe(users => {
      this.activeUsers = users;
    });
  }
  async loadInactiveUsers() {
    console.log('Loading inactive users');
    console.log(this.allUsers);
    await this.userService.getInactiveUsers().subscribe(users => {
      this.inactiveUsers = users;
      console.log(this.allUsers);
    })
  }
*/