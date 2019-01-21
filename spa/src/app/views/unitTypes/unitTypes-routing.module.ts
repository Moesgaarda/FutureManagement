import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewUnitTypesComponent } from './view-unitTypes.component';
import { DetailsUnitTypeComponent } from './details-unitType.component';
import { NewUnitTypeComponent } from './new-unitType.component';
import { AuthGuard } from '../../_guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Mængdeenheder',
      roles: ['UnitTypes_View']
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
        component: ViewUnitTypesComponent,
        data: {
          roles: ['UnitTypes_View'],
          title: 'Vis mængdeenheder'
        },
      },
      {
        path: 'new',
        component: NewUnitTypeComponent,
        data: {
          roles: ['UnitTypes_Add'],
          title: 'Tilføj mængdeenhed'
        },
      },
      {
        path: 'details/:id',
        component: DetailsUnitTypeComponent,
        data: {
          roles: ['UnitTypes_View'],
          title: 'Vis detaljer'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UnitTypesRoutingModule {}
