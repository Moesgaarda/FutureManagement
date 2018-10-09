import { Component } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import * as _ from 'underscore';
import { Order } from '../../_models/Order';
import { environment } from '../../../environments/environment';
import { OrderService } from '../../_services/order.service';

@Component({
    templateUrl: './view-orders.component.html',
    styles: [`
      nb-card {
        transform: translate3d(0, 0, 0);
      }
    `],
  })
export class ViewOrdersComponent {
    baseUrl = environment.spaUrl;
    source: LocalDataSource;
    orders: Order[];

    settings = {
        attr: {
            class: 'table table-striped pagination'
        },
        pager: {
          perPage: 15,
        },
        mode: 'external',
        delete: {
          deleteButtonContent: '<i class="btn btn-sm btn-danger fa fa-trash"> Slet </i>',
          confirmDelete: true,
        },
        add: {
          addButtonContent: 'Tilføj ny genstand'
        },
        edit: {
          editButtonContent: '<i class="btn btn-sm btn-primary fa fa-edit"> Rediger </i>',
          saveButtonContent: '<i class="btn btn-sm btn-info fa fa-save"> Gem </i>',
          cancelButtonContent: '<i class="btn btn-sm btn-warning fa fa-trash"> Fortryd </i>',
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
        });
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

