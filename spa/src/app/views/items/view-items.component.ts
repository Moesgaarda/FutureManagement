import { Component, OnInit } from '@angular/core';
import { ItemService } from '../../_services/item.service';
import { environment } from '../../../environments/environment';
import * as _ from 'underscore';
import { Item } from '../../_models/Item';
import * as pdfMake from 'pdfmake/build/pdfmake';
import * as pdfFonts from 'pdfmake/build/vfs_fonts';

@Component({
  templateUrl: './view-items.component.html',
  styles: [`
    nb-card {
      transform: translate3d(0, 0, 0);
    }
  `],
})
export class ViewItemsComponent implements OnInit {
  private allItems: Item[];
  baseUrl = environment.spaUrl;
  public rows: Array<any> = [];
  public columns: Array<any> = [
    {title: 'Navn', name: 'template.name'},
    {title: 'Mængde', name: 'amount'},
    {title: 'Placering', name: 'placement'},
    {title: 'Er aktiv', name: 'isActive'},
];
  public page = 1;
  public itemsPerPage = 5;
  public maxSize = 5;
  public numPages = 1;
  public length = 0;

  public config: any = {
    paging: true,
    sorting: {columns: this.columns},
    filtering: {filterString: ''},
    className: ['table-striped', 'table-bordered']
  };

  private data: Array<any> = [];

  public changePage(page: any, data: Array<any> = this.data): Array<any> {
    const start = (page.page - 1) * page.itemsPerPage;
    const end = page.itemsPerPage > -1 ? (start + page.itemsPerPage) : data.length;
    return data.slice(start, end);
  }

  public changeSort(data: any, config: any): any {
    if (!config.sorting) {
      return data;
    }

    const columns = this.config.sorting.columns || [];
    let columnName: string = void 0;
    let sort: string = void 0;

    for (let i = 0; i < columns.length; i++) {
      if (columns[i].sort !== '' && columns[i].sort !== false) {
        columnName = columns[i].name;
        sort = columns[i].sort;
      }
    }

    if (!columnName) {
      return data;
    }

    // simple sorting
    return data.sort((previous: any, current: any) => {
      if (previous[columnName] > current[columnName]) {
        return sort === 'desc' ? -1 : 1;
      } else if (previous[columnName] < current[columnName]) {
        return sort === 'asc' ? -1 : 1;
      }
      return 0;
    });
  }

  public changeFilter(data: any, config: any): any {
    let filteredData: Array<any> = data;
    this.columns.forEach((column: any) => {
      if (column.filtering) {
        filteredData = filteredData.filter((item: any) => {
          return item[column.name].match(column.filtering.filterString);
        });
      }
    });
    const tempArray: Array<any> = [];
    filteredData.forEach((item: any) => {
      let flag = false;
      this.columns.forEach((column: any) => {
        const correctPath = this.fixPropPath(column.name, item);
        if ((correctPath.toString().toLowerCase()).match(this.config.filtering.filterString.toLowerCase())) {
          flag = true;
        }
      });
      if (flag) {
        tempArray.push(item);
      }
    });
    filteredData = tempArray;

    return filteredData;
  }

  public onChangeTable(config: any, page: any = {page: this.page, itemsPerPage: this.itemsPerPage}): any {
    if (config.filtering) {
      Object.assign(this.config.filtering, config.filtering);
    }

    if (config.sorting) {
      Object.assign(this.config.sorting, config.sorting);
    }

    const filteredData = this.changeFilter(this.data, this.config);
    const sortedData = this.changeSort(filteredData, this.config);
    this.rows = page && config.paging ? this.changePage(page, sortedData) : sortedData;
    this.length = sortedData.length;
  }

  public onCellClick(data: any): any {
    location.href = this.baseUrl + 'items/details/' + data.row.id;
  }
  /*  method to sterialize path to a given property in a object
  *   Example:
  *    item[column.name] --> item["template.name"]
  *   This gives an undefined error
  *   It should be:
  *     Item[column][name] --> Item["template"]["name"]
  *   This is what fixPropPath method does
  */
  public fixPropPath(path, obj) {
    return path.split('.').reduce(function(prev, curr) {
        return prev ? prev[curr] : null;
    }, obj || self);
  }

  ngOnInit() {
    this.loadItems();
  }
  constructor(private itemService: ItemService) {
    pdfMake.vfs = pdfFonts.pdfMake.vfs;
  }

  async loadItems() {
    await this.itemService.getAll().subscribe(items => {
      this.rows = items;
      this.data = items;
      this.onChangeTable(this.config);
      this.allItems = items;
    });

  }

  addNewItem() {
    location.href = this.baseUrl + 'items/new';
  }

  getTableAsPdf() {
    this.loadItems();
    const docDefinition = {
      content: [
        { text: 'Alle genstande', style: 'header' },
        this.table(this.allItems, ['id', 'template', 'placement', 'amount', 'isActive'],
                            ['Id', 'Skabelonens navn', 'Placering', 'Mængde', 'Aktivt'])
      ]
    };
    pdfMake.createPdf(docDefinition).open({}, window);
  }

  buildPdfTableBody(data, columns, headers) {
    const body = [];
    body.push(headers);
    data.forEach(function(row) {
        const dataRow = [];

        columns.forEach(function(column) {
          if (column === 'template') {
            dataRow.push(row[column].name);
          } else {
            dataRow.push(row[column].toString());
          }
        });

        body.push(dataRow);
    });

    return body;
  }

  table(data, columns, headers) {
    const widths = [];
    const width = (100.0 / columns.length).toString() + '%';

    for (let i = 0; i < columns.length; i++ ) {
      widths.push(width);
    }
    return {
        table: {
            headerRows: 1,
            body: this.buildPdfTableBody(data, columns, headers),
            widths: widths
        }
    };
  }

}
