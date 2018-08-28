import { Component } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { environment } from '../../../../environments/environment';
import { OrderService } from '../../../_services/order.service';
import { Order } from '../../../_models/Order';
import * as _ from 'underscore';

@Component({
    selector: 'ngx-order-table',
    templateUrl: './order-table.component.html',
    styles: [`
      nb-card {
        transform: translate3d(0, 0, 0);
      }
    `],
})

export class OrderTableComponent {
    baseUrl = environment.spaUrl;
    source: LocalDataSource;
    orders: Order[];

    settings = {
        pager: {
          perPage: 15,
        },
        mode: 'external',
        delete: {
          deleteButtonContent: '<i class="nb-trash"></i>',
          confirmDelete: true,
        },
        add: {
          addButtonContent: 'Tilføj ny',
        },
        edit: {
          editButtonContent: '<i class="nb-edit"></i>',
          saveButtonContent: '<i class="nb-checkmark"></i>',
          cancelButtonContent: '<i class="nb-close"></i>',
        },
        columns: {
            company: {
                title: 'Firma',
                type: 'string',
            },
            deliveryDate: {
                title: 'Levering',
                type: 'string',
            },
            purchaseNumber: {
                title: 'Købsnummer',
                type: 'number',
            },
        },
    };

    constructor(private orderService: OrderService) {
        this.source = new LocalDataSource();
        this.loadOrders();
    }

    async loadOrders() {
        await this.orderService.getAllOrders().subscribe(orders => {
          this.orders = orders;
          this.source.load(orders);
          this.source.refresh();
        })
    }

    onDeleteConfirm(event): void {
        if (window.confirm('Er du sikker på at du vil slette denne forekomst?')) {
          event.confirm.resolve();
        } else {
          event.confirm.reject();
        }
    }

    addNewOrder() {
        location.href = this.baseUrl + '/pages/forms/order';
    }

    editOrder(orderToLoad): void {
        location.href = this.baseUrl + '/pages/forms/order-detail/' + orderToLoad.data.id;
    }

    deleteOrder(orderToDelete): void {
        if (window.confirm('Er du sikker på at du vil slette denne bestilling?')) {
          this.orderService.deleteOrder(orderToDelete.data.id).subscribe(() => {
            this.orders.splice(_.findIndex(this.orders, {id: orderToDelete.data.id}), 1);
            this.source.refresh();
          });
        }
    }
}

