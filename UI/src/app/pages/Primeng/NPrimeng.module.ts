import { NgModule } from '@angular/core';
import { DataViewModule } from 'primeng/dataview';

import { ThemeModule } from '../../@theme/theme.module';
import { NPrimengRoutingModule } from './NPrimeng-routing.module';
import { routedComponents } from './NPrimeng-routing.module';
import { HttpModule } from '@angular/http';
import {DropdownModule} from 'primeng/dropdown';
import {PanelModule} from 'primeng/panel';
import {DialogModule} from 'primeng/dialog';

@NgModule({
  imports: [
    HttpModule,
    ThemeModule, DataViewModule,DropdownModule,PanelModule,DialogModule,
    NPrimengRoutingModule
  ],
  providers: [ ],
  declarations: [...routedComponents]
})
export class NPrimengModule { }
