import {Component, OnInit} from '@angular/core';
import {CategoryService} from '../../_services/category.service';
import {ActivatedRoute, Router} from '@angular/router';
import {Category} from '../../_models/Category';
import {AlertifyService} from '../../_services/alertify.service';


@Component({
  templateUrl: './edit-category.component.html'
})
export class EditCategoryComponent implements OnInit {

  category = {} as Category;

  constructor(private categoryService: CategoryService, private route: ActivatedRoute, private alertify: AlertifyService,
              private router: Router) {
  }

  ngOnInit() {
    this.categoryService.getCategory(+this.route.snapshot.params['id'])
      .subscribe(category => {
        this.category = category;
      });
  }

  Save() {
    console.log(this.category);
    this.categoryService.editCategory(this.category).subscribe(
      category => {
        this.category = category;
        this.alertify.success('Opdaterede kategori');
      },
      error => {
        this.alertify.error('Kunne ikke opdatere kategori');
      }, () => {
        this.router.navigate(['categories/view']);
      });
  }
}
