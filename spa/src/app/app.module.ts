import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { HttpModule} from '@angular/http';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';


import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true
};

import { AppComponent } from './app.component';

// Import containers
import { DefaultLayoutComponent } from './containers';

import { LoginComponent } from './views/login/login.component';

const APP_CONTAINERS = [
  DefaultLayoutComponent
];

import {
  AppAsideModule,
  AppBreadcrumbModule,
  AppHeaderModule,
  AppFooterModule,
  AppSidebarModule,
} from '@coreui/angular';

// Import routing module
import { AppRoutingModule } from './app.routing';

// Import 3rd party components
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ChartsModule } from 'ng2-charts/ng2-charts';

import { ItemService } from './_services/item.service';
import { ItemTemplateService } from './_services/itemTemplate.service';
import { UserService } from './_services/user.service';
import { OrderService } from './_services/order.service';
import { AlertifyService } from './_services/alertify.service';
import { CustomerService } from './_services/customer.service';
import { EventLogService } from './_services/eventLog.service';
import { AuthService } from './_services/auth.service';
import { FileUploadService} from './_services/fileUpload.service';
import { AuthGuard } from './_guards/auth.guard';
import { Interceptor } from './_services/http.interceptor';
import { CustomSidebarComponent } from './views/custom-sidebar/custom-sidebar.component';
import { UnitTypeService } from './_services/unitType.service';
import { CategoryService } from './_services/category.service';
import { TemplatePropertyService } from './_services/templateProperty.service';
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';

@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    AppAsideModule,
    AppBreadcrumbModule.forRoot(),
    AppFooterModule,
    AppHeaderModule,
    AppSidebarModule,
    PerfectScrollbarModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    ChartsModule,
    HttpClientModule,
    HttpModule,
    FormsModule,
    NgSelectModule,
    Ng4LoadingSpinnerModule.forRoot()
  ],
  declarations: [
    AppComponent,
    ...APP_CONTAINERS,
    LoginComponent,
    CustomSidebarComponent
  ],
  providers: [
  {
    provide: HTTP_INTERCEPTORS,
    useClass: Interceptor,
    multi: true
  },
  ItemService,
  ItemTemplateService,
  UserService,
  OrderService,
  CustomerService,
  EventLogService,
  UnitTypeService,
  AuthService,
  AlertifyService,
  FileUploadService,
  CategoryService,
  TemplatePropertyService,
  AuthGuard
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
