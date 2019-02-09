import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../_services/order.service';
import { Order } from '../../_models/Order';
import { ActivatedRoute, Router } from '@angular/router';
import { DetailFile } from '../../_models/DetailFile';
import { FileUploadService } from '../../_services/fileUpload.service';
import { OrderStatusEnum } from '../../_enums/OrderStatusEnum.enum';
import { formatDate } from '@angular/common';
import { AuthService } from '../../_services/auth.service';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  templateUrl: './details-order.component.html'
})
export class DetailsOrderComponent implements OnInit {
  isDataAvailable = false;
  order: Order;
  files: DetailFile[];
  orderStatus: string;
  deliveryDateString: string;
  orderDateString: string;
  isEditing = false;
  keys: string[];
  orderStatusEnum = OrderStatusEnum;


  constructor(
    private orderService: OrderService,
    private route: ActivatedRoute,
    private fileUploadService: FileUploadService,
    private router: Router,
    private alertify: AlertifyService,
    public authService: AuthService
  ) {

  }

  async ngOnInit() {
    await this.loadOrderOnInIt();
  }

  async loadOrderOnInIt() {
    await this.orderService.getOrder(+this.route.snapshot.params['id'])
      .then(order => {
        this.order = order;
        this.orderStatus = OrderStatusEnum[order.status].toString();
        this.orderDateString = formatDate(order.orderDate, 'dd/MM/yyyy', 'en-US');
        this.deliveryDateString = formatDate(this.order.deliveryDate, 'dd/MM/yyyy', 'en-US');
        this.keys = Object.keys(this.orderStatusEnum);
        this.keys = this.keys.slice(this.keys.length / 2 );
        this.isDataAvailable = true;
      });
  }

  editStatus() {
    this.isEditing = true;
  }

  saveStatus() {
    if (this.orderStatus === this.keys[this.order.status]) {
      this.isEditing = false;
    } else {
      this.order.status = this.orderStatusEnum[this.orderStatus];
      this.orderService.editOrderStatus(this.order).subscribe(
        data => {
            this.alertify.success('Ændringer gemt');
        },
        error => {
            this.alertify.error('Kunne ikke gemme ændringer');
        },
        () => {
            this.isEditing = false;
        }
    );
    }
  }

  goToItemTemplateDetail(templateId: number) {
    this.router.navigateByUrl('itemTemplates/details/' + templateId);
  }

  goToEditPage(orderId: number) {
    this.router.navigateByUrl('orders/edit/' + orderId);
  }

  downloadFile(fileDetails: DetailFile) {
    this.fileUploadService.download(fileDetails, 'Order');
  }
}
