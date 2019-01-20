import { OnInit, Component } from '@angular/core';
import { OrderService } from '../../_services/order.service';
import { AlertifyService } from '../../_services/alertify.service';
import { Order } from '../../_models/Order';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderStatusEnum } from '../../_enums/OrderStatusEnum.enum'

@Component({
    templateUrl: './edit-order.component.html'
})

export class EditOrderComponent implements OnInit {
    order: Order;
    isDataAvailable: boolean;
    orderStatus: string;
    orderStatusEnum = OrderStatusEnum;
    keys: string[];

    constructor(private orderService: OrderService, private alertify: AlertifyService, private route: ActivatedRoute,
        private router: Router) { }

    async ngOnInit() {
        await this.loadOrderOnInIt();
        this.keys = Object.keys(this.orderStatusEnum).filter(f => !isNaN(Number(f)));
    }

    async loadOrderOnInIt() {
        await this.orderService.getOrder(+this.route.snapshot.params['id'])
            .then(order => {
                this.order = order;
                this.orderStatus = OrderStatusEnum[order.status].toString();
                this.isDataAvailable = true;
            });
    }

    updateStatus() {
        this.order.status = this.orderStatusEnum[this.orderStatus];
        console.log(this.order);
        this.orderService.statusUpdateOrder(this.order).subscribe(
            order => {
                this.alertify.success('Status opdateret');
            },
            error => {
                this.alertify.error('Kunne ikke gennemføre ændringerne');
            }, () => {
                this.router.navigate(['order/details/' + this.order.id]);
            });
    }
}
