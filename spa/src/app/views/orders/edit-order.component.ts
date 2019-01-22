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
    dateAsString = '';
    date: Date;
    year = '';
    month = '';
    day = '';
    dataAvailable = false;


    constructor(private orderService: OrderService, private alertify: AlertifyService, private route: ActivatedRoute,
        private router: Router) { }

    async ngOnInit() {
        this.keys = Object.keys(this.orderStatusEnum);
        this.keys = this.keys.slice(this.keys.length / 2 );
        await this.loadOrderOnInIt();
        this.convertDate();
        this.date = new Date(this.dateAsString);
        console.log(this.order);
        this.dataAvailable = true;
    }

    async loadOrderOnInIt() {
        await this.orderService.getOrder(+this.route.snapshot.params['id'])
            .then(order => {
                this.order = order;
                this.orderStatus = OrderStatusEnum[order.status].toString();
                this.isDataAvailable = true;
            });
    }

    saveOrder() {
        this.order.status = this.orderStatusEnum[this.orderStatus];
        console.log(this.order);
        this.orderService.editOrder(this.order).subscribe(
            order => {
                this.alertify.success('Status opdateret');
            },
            error => {
                this.alertify.error('Kunne ikke gennemføre ændringerne');
            }, () => {
                this.router.navigate(['orders/details/' + this.order.id]);
            });
    }

    convertDate() {
        for (let i = 0; i < 10; i++) {
            if(i <= 3){
                this.year = this.year.concat(this.order.deliveryDate[i]);
            } else if(i === 5 || i === 6) {
                this.month = this.month.concat(this.order.deliveryDate[i]);
            } else if (i === 8 || i === 9){
                this.day = this.day.concat(this.order.deliveryDate[i]);
            }
        }
        this.dateAsString = this.day + '/' + this.month + '/' + this.year;

    }
}
