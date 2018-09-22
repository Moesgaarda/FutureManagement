import { Component } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { environment } from '../../../environments/environment';
import * as _ from 'underscore';
import { Customer } from '../../_models/Customer';
import { CustomerService } from '../../_services/customer.service';


@Component({
  templateUrl: './view-customers.component.html',
  styles: [`
    nb-card {
      transform: translate3d(0, 0, 0);
    }
  `],
})
export class ViewCustomersComponent {
  customers: Customer[];
  source: LocalDataSource;

  settings = {
    add: {
      addButtonContent: '<i class="nb-plus"></i>',
      createButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
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
      email: {
        title: 'E-mail',
        type: 'string',
      },
    },
  };

  constructor(private service: CustomerService) {
    this.source = new LocalDataSource();
    this.loadCustomers();
  }

  async loadCustomers() {
    await this.service.getAllCustomers().subscribe(customers => {
      this.customers = customers;
      this.source.load(customers);
      this.source.refresh();
    });
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Er du sikker på at du vil slette denne kunde?')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }
}
