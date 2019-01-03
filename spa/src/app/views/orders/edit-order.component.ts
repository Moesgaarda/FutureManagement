import { OnInit, Component } from '@angular/core';
import { OrderService } from '../../_services/order.service';
import { AlertifyService } from '../../_services/alertify.service';
import { Order } from '../../_models/Order';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderStatus } from '../../_models/OrderStatus';

@Component({
    templateUrl: './edit-order.component.html'
})

export class EditOrderComponent implements OnInit {
    order: Order;
    isDataAvailable: boolean;
    statuses: OrderStatus[];

    constructor(private orderService: OrderService, private alertify: AlertifyService, private route: ActivatedRoute,
        private router: Router) { }

    async ngOnInit() {
        await this.loadOrderOnInIt();
        await this.getStatuses();
    }

    async loadOrderOnInIt() {
        await this.orderService.getOrder(+this.route.snapshot.params['id'])
            .then(order => {
                this.order = order;
                this.isDataAvailable = true;
            });
    }

    async getStatuses() {
        await this.orderService.getAllStatuses().then(statuses => {
            this.statuses = statuses;
        });
    }

    //    editItem() {
    //        this.itemService.editItem(this.item).subscribe(item => { }, error => {
    //            this.alertify.error('Kunne ikke gennemføre ændringerne');
    //        }, () => {
    //            this.alertify.success('Ændringer gemt');
    //            this.router.navigate(['items/details/' + this.item.id]);
    //        });
    //    }
}
