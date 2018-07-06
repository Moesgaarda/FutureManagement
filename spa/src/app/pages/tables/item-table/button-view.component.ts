import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { ViewCell } from 'ng2-smart-table';

@Component({
  selector: 'ngx-button-view',
})
export class ButtonViewComponent implements ViewCell{
  renderValue: string;

  @Input() value: string | number;
  @Input() rowData: any;

  @Output() save: EventEmitter<any> = new EventEmitter();

  onClick() {
    this.save.emit(this.rowData);
  }
}
