import { OnInit, Component } from '@angular/core';
import { OrderService } from '../../_services/order.service';
import { AlertifyService } from '../../_services/alertify.service';
import { Order } from '../../_models/Order';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    templateUrl: './edit-order.component.html'
})

export class EditOrderComponent implements OnInit {
    order: Order;
    isDataAvailable: boolean;

    constructor(private orderService: OrderService, private alertify: AlertifyService, private route: ActivatedRoute,
        private router: Router) { }

    async ngOnInit() {
        await this.loadOrderOnInIt();
    }

    async loadOrderOnInIt() {
        await this.orderService.getOrder(+this.route.snapshot.params['id'])
            .then(order => {
                this.order = order;
                this.isDataAvailable = true;
            });
    }

    updateStatus() {
        this.orderService.statusUpdateOrder(this.order).subscribe(order => { }, error => {
            this.alertify.error('Kunne ikke gennemføre ændringerne');
        }, () => {
            this.alertify.success('Status opdateret');
            this.router.navigate(['order/details/' + this.order.id]);
        });
    }
}
