
import { Component, OnInit } from '@angular/core';
import { UnitTypeService } from '../../_services/unitType.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UnitType } from '../../_models/UnitType';
import { AlertifyService } from '../../_services/alertify.service';


@Component({
  templateUrl: './edit-unitType.component.html'
})
export class EditUnitTypeComponent implements OnInit {

  constructor(private unitTypeService: UnitTypeService, private route: ActivatedRoute, private alertify: AlertifyService,
              private router: Router) {}

  unitType = {} as UnitType;

  ngOnInit() {
    this.unitTypeService.getUnitType(+this.route.snapshot.params['id'])
      .subscribe(unitType => {
        this.unitType = unitType;
      });
  }

  Save() {
    console.log(this.unitType);
        this.unitTypeService.editUnitType(this.unitType).subscribe(
          unitType => {
            this.unitType = unitType;
            this.alertify.success('Opdaterede mængdeenhed');
          },
          error => {
            this.alertify.error('Kunne ikke opdatere mængdeenhed');
          }, () => {
            this.router.navigate(['unitTypes/view']);
          });
    }
}
