import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import * as _ from 'underscore';
import { Category } from '../../_models/Category';
import { AlertifyService } from '../../_services/alertify.service';
import { Router } from '@angular/router';
import { AuthService } from '../../_services/auth.service';
import { CategoryService } from '../../_services/category.service';

@Component({
  templateUrl: './new-category.component.html',
  styles: ['../../../scss/_custom.scss']
})

export class NewCategoryComponent {
  baseUrl = environment.spaUrl;
  category = {} as Category;

  constructor(private categoryService: CategoryService, private alertify: AlertifyService, private router: Router) {}

  addCategory() {
      this.categoryService.addCategory(this.category).subscribe(() => {
        this.alertify.success('Kategori blev oprettet');
        this.router.navigate(['categories/view/']);
      }, error => {
        this.alertify.error('Kunne ikke tilføje kategori');
      });
  }
}
