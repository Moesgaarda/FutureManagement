
import { Component, OnInit } from '@angular/core';
import { UnitTypeService } from '../../_services/unitType.service';
import { ActivatedRoute } from '@angular/router';
import { UnitType } from '../../_models/UnitType';


@Component({
  templateUrl: './edit-unitType.component.html'
})
export class EditUnitTypeComponent implements OnInit {

  constructor(private unitTypeService: UnitTypeService, private route: ActivatedRoute) {}

  unitType: UnitType;
  editDisabled: boolean;

  ngOnInit() {
    this.unitTypeService.getUnitType(+this.route.snapshot.params['id'])
      .subscribe(unitType => {
        this.unitType = unitType;
      });
    this.editDisabled = true;
  }

  enableEdit(save: boolean, str: string) {
    if (this.editDisabled) {
      this.editDisabled = false;
    } else {
      if (save) {
        this.unitType.name = str;
        this.unitTypeService.editUnitType(this.unitType).subscribe(r => {});
      }
      this.editDisabled = true;
    }
  }

}
