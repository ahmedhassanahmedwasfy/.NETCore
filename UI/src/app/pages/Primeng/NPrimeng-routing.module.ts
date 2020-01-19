import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router'; 
import { DataViewComponent } from './components/DataView/DataView.component';
import { PrimengComponent } from './Primeng.component';

const routes: Routes = [{
  path: '',
  component:DataViewComponent ,
  children: [{
    path: 'dataview',
    component: DataViewComponent,
  }],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class NPrimengRoutingModule { }

export const routedComponents = [
  DataViewComponent,
  PrimengComponent,
];
