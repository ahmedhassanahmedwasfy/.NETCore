import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdministrationComponent } from './Administration.component';
import { AdministrationRoutingModule, routedComponents } from './Administration-routing.module';
import { ThemeModule } from '../../@theme/theme.module';
import { UsersComponent } from './Users/Users.component';
import { GroupsComponent } from './Groups/Groups.component';

@NgModule({
  imports: [
    ThemeModule,AdministrationRoutingModule
  ],
  declarations: [...routedComponents]
})
export class AdministrationModule { }
