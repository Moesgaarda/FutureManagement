import { Component, OnInit, Input } from '@angular/core';
import { ItemTemplate, UnitType } from '../../_models/ItemTemplate';
import { ItemTemplateService } from '../../_services/itemTemplate.service';
import { ItemService } from '../../_services/item.service';
import { environment } from '../../../environments/environment';
import * as _ from 'underscore';
import { Injector } from '@angular/core';
import { OrderService } from '../../_services/order.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  selector: 'app-techtable',
  templateUrl: './techtable.component.html',
  styleUrls: ['./techtable.component.scss']
})

export class TechtableComponent implements OnInit {
  baseUrl = environment.spaUrl;
  public rows: Array<any> = [];
  @Input() columns: Array<any> = [];

  public page = 1;
  public itemsPerPage = 5;
  public maxSize = 5;
  public numPages = 1;
  public length = 0;
  @Input() serviceType: string;

  private tableService;
  public config: any = {
    paging: true,
    sorting: {columns: this.columns},
    filtering: {filterString: ''},
    className: ['table-striped', 'table-bordered']
  };
  private data: Array<any> = [];

  // TODO Add additional services or figure out how to use the string literal as service
  /**
   * The ngOnInit handles getting the correct serviceType, depending on the string
   * passed from the HTML call.
   * @memberof TechtableComponent
   */
  ngOnInit() {
    if (this.serviceType === 'ItemService') {
      this.tableService = <ItemService>this.injector.get(ItemService);
    } else if (this.serviceType === 'ItemTemplateService') {
      this.tableService = <ItemTemplateService>this.injector.get(ItemTemplateService);
    } else if (this.serviceType === 'OrderService') {
      this.tableService = <OrderService>this.injector.get(OrderService);
    } else {
      console.log('Unexpected service name: ' + this.serviceType);
    }
    this.loadItems();
  }

  constructor(private injector: Injector, private alertify: AlertifyService) {
  }

  /**
   * Loads items from the tableService specified in ngOnInit() and
   * places the data in the rows and tables.
   * @memberof TechtableComponent
   */
  async loadItems() {
    await this.tableService.getAll().subscribe(items => {
      this.rows = items;
      this.data = items;
      this.onChangeTable(this.config);
    });
  }


  /**
   * ChangePage is called every time the page on the table is changed and handles
   * receiving the correct output for the user.
   *
   * @param {*} page handles the current page.
   * @param {Array<any>} [data=this.data] gets the attached data.
   * @returns {Array<any>} Returns the data that is located between start and end.
   * @memberof TechtableComponent
   */
  public changePage(page: any, data: Array<any> = this.data): Array<any> {
    const start = (page.page - 1) * page.itemsPerPage;
    const end = page.itemsPerPage > -1 ? (start + page.itemsPerPage) : data.length;
    return data.slice(start, end);
  }

  /**
   * changeSort changes the sorting method.
   *
   * @param {*} data the data received
   * @param {*} config the currect configuration for sorting
   * @returns {*} returns the data in a sorted manner according to config
   * @memberof TechtableComponent
   */
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

  /**
   * Updates the table depending on the filter that is input in the
   *  search field.
   * @param {*} data the data received
   * @param {*} config the currect configuration for sorting
   * @returns {*}
   * @memberof TechtableComponent
   */
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

  /**
   * Is called whenever the table changes state. This can happen
   * if sorting or filtering is changed.
   *
   * @param {*} config Current configuration
   * @param {*} [page={page: this.page, itemsPerPage: this.itemsPerPage}] Information about the page from html
   * @returns {*} None
   * @memberof TechtableComponent
   */
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

  /**
   * Redirects the user based on the injected service
   *
   * @param {*} data
   * @returns {*}
   * @memberof TechtableComponent
   */
  public onCellClick(data: any): any {
    if (this.serviceType === 'ItemService') {
      location.href = this.baseUrl + 'items/details/' + data.row.id;
    } else if (this.serviceType === 'ItemTemplateService') {
      location.href = this.baseUrl + 'itemTemplates/details/' + data.row.id;
    } else if (this.serviceType === 'OrderService') {
      location.href = this.baseUrl + 'orders/details/' + data.row.id;
    } else {
      this.alertify.error('Unexpected service name: ' + this.serviceType);
    }
  }


   /**  method to sterialize path to a given property in a object
   *   Example:
   *    item[column.name] --> item["template.name"]
   *   This gives an undefined error
   *   It should be:
   *     Item[column][name] --> Item["template"]["name"]
   *   This is what fixPropPath method does
   *
   * @param {*} path
   * @param {*} obj
   * @returns
   * @memberof TechtableComponent
   */
  public fixPropPath(path, obj) {
    return path.split('.').reduce(function(prev, curr) {
        return prev ? prev[curr] : null;
    }, obj || self);
  }


}
