import { OnInit, Component } from '@angular/core';
import { ItemService } from '../../_services/item.service';
import { AlertifyService } from '../../_services/alertify.service';
import { Item } from '../../_models/Item';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    templateUrl: './edit-item.component.html'
})

export class EditItemComponent implements OnInit {
    item: Item;
    itemLoaded: boolean;

    constructor(private itemService: ItemService, private alertify: AlertifyService,  private route: ActivatedRoute,
        private router: Router) { }

    ngOnInit() {
        this.loadItem();
    }

    async loadItem() {
        await this.itemService
            .getItem(+this.route.snapshot.params['id'])
            .subscribe((item: Item) => {
                this.item = item;
            }, error => {
                this.alertify.error('Kunne ikke hente info om genstanden');
            }, () => {
                this.itemLoaded = true;
            });
    }

    editItem() {
        this.itemService.editItem(this.item).subscribe(item => {}, error => {
            this.alertify.error('Kunne ikke gennemføre ændringerne');
            console.log(this.item);
        }, () => {
            this.alertify.success('Ændringer gemt');
            this.router.navigate(['items/details/' + this.item.id]);
        });
    }
}
