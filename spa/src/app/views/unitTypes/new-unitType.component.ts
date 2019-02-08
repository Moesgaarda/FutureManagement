import {Component} from '@angular/core';
import {environment} from '../../../environments/environment';
import {UnitType} from '../../_models/UnitType';
import {AlertifyService} from '../../_services/alertify.service';
import {Router} from '@angular/router';
import {UnitTypeService} from '../../_services/unitType.service';

@Component({
  templateUrl: './new-unitType.component.html',
  styles: ['../../../scss/_custom.scss']
})

export class NewUnitTypeComponent {
  baseUrl = environment.spaUrl;
  unitType = {} as UnitType;

  constructor(private unitTypeService: UnitTypeService, private alertify: AlertifyService, private router: Router) {
  }

  addUnitType() {
    this.unitTypeService.addUnitType(this.unitType).subscribe(() => {
      this.alertify.success('Mængdeenhed blev oprettet');
      this.router.navigate(['unitTypes/view/']);
    }, error => {
      this.alertify.error('Kunne ikke tilføje mængdeenhed');
    });
  }
}
