import { Component } from '@angular/core';

@Component({
  selector: 'ngx-item-template-detail-form',
  styleUrls: ['../form-inputs/form-inputs.component.scss'],
  templateUrl: './item-template-detail-form.component.html',
})
export class ItemTemplateDetailFormComponent {
  unitTypeDisabled: boolean;
  nameDisabled: boolean;
  fileDisabled: boolean;
  descriptionDisabled: boolean;

  ngOnInit() {
    this.nameDisabled = true;
    this.fileDisabled = true;
    this.unitTypeDisabled = true;
    this.descriptionDisabled = true;
  }

  enableName() {
    if (this.nameDisabled) {
      this.nameDisabled = false;
    }
    else {
      // indsæt i db
      this.nameDisabled = true;
    }   
  }

  enableunitType() {
    if (this.unitTypeDisabled) {
      this.unitTypeDisabled = false;
    }
    else {
      // indsæt i db
      this.unitTypeDisabled = true;
    }
  }

  enableDescription() {
    if (this.descriptionDisabled) {
      this.descriptionDisabled = false;
    }
    else {
      // indsæt i db
      this.descriptionDisabled = true;
    }
  }

  enableFile() {
    if (this.fileDisabled) {
      this.fileDisabled = false;
    }
    else {
      // indsæt i db
      this.fileDisabled = true;
    }
  }
}