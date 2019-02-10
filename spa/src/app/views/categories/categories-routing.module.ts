import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewCategoriesComponent } from './view-categories.component';
import { EditCategoryComponent } from './edit-category.component';
import { NewCategoryComponent } from './new-category.component';
import { AuthGuard } from '../../_guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Kategori',
      roles: ['Categories_View']
    },
    runGuardsAndResolvers: 'always',
    canActivateChild: [AuthGuard],
    children: [
      {
        path: '',
        redirectTo: 'view'
      },
      {
        path: 'view',
        component: ViewCategoriesComponent,
        data: {
          roles: ['Categories_View'],
          title: 'Vis kategorier'
        },
      },
      {
        path: 'new',
        component: NewCategoryComponent,
        data: {
          roles: ['Categories_Add'],
          title: 'Tilføj kategori'
        },
      },
      {
        path: 'edit/:id',
        component: EditCategoryComponent,
        data: {
          roles: ['Categories_Add'],
          title: 'Rediger mængdeenhed'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoriesRoutingModule {}
