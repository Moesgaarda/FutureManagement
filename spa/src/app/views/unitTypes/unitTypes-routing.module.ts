import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ViewUnitTypesComponent} from './view-unitTypes.component';
import {EditUnitTypeComponent} from './edit-unitType.component';
import {NewUnitTypeComponent} from './new-unitType.component';
import {AuthGuard} from '../../_guards/auth.guard';

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
        path: 'edit/:id',
        component: EditUnitTypeComponent,
        data: {
          roles: ['UnitTypes_Add'],
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
export class UnitTypesRoutingModule {
}
