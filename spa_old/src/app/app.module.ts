/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { CoreModule } from './@core/core.module';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ThemeModule } from './@theme/theme.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from './pages/forms/forms.module';
import { AuthService } from './_services/auth.service';
import { HttpModule } from '@angular/http';
import { ItemTemplateService } from './_services/itemTemplate.service';
import { ItemService } from './_services/item.service';
import { EventLogService } from './_services/eventLog.service';
import { UserService } from './_services/user.service';
import { ErrorInterceptorProvide } from './_services/error.interceptor';
import { NewModule } from './pages/new/new.module';
import { AuthGuard } from './_guards/auth.guard';
import { AlertifyService } from './_services/alertify.service';
import { OrderService } from './_services/order.service';
import {FileUploadComponent} from './pages/components/file-upload/file-upload.component';


@NgModule({
  declarations: [
    AppComponent,
    FileUploadComponent,

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    HttpModule,
    NewModule,

    NgbModule.forRoot(),
    ThemeModule.forRoot(),
    CoreModule.forRoot(),
  ],
  bootstrap: [AppComponent],
  providers: [
    { provide: APP_BASE_HREF, useValue: '/' },
    AuthService,
    ItemTemplateService,
    ItemService,
    EventLogService,
    UserService,
    OrderService,
    ErrorInterceptorProvide,
    AuthGuard,
    AlertifyService,
    FileUploadComponent,
  ],
})
export class AppModule {
}
