import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewTemplatePropertiesComponent } from './view-templateProperties.component';
import { EditTemplatePropertyComponent } from './edit-templateProperty.component';
import { NewTemplatePropertyComponent } from './new-templateProperty.component';
import { AuthGuard } from '../../_guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Egenskab',
      roles: ['TemplateProperties_View']
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
        component: ViewTemplatePropertiesComponent,
        data: {
          roles: ['TemplateProperties_View'],
          title: 'Vis egenskaber'
        },
      },
      {
        path: 'new',
        component: NewTemplatePropertyComponent,
        data: {
          roles: ['TemplateProperties_Add'],
          title: 'Tilføj egenskaber'
        },
      },
      {
        path: 'edit/:id',
        component: EditTemplatePropertyComponent,
        data: {
          roles: ['TemplateProperties_Add'],
          title: 'Rediger egenskaber'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TemplatePropertiesRoutingModule {}
