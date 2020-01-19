import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersComponent } from './Users/Users.component';
import { GroupsComponent } from './Groups/Groups.component';
import { AdministrationComponent } from './Administration.component';
import { UsersIndexComponent } from './UsersIndex/UsersIndex.component';
import { GroupsIndexComponent } from './GroupsIndex/GroupsIndex.component';
import { ProfileComponent } from './Profile/Profile.component';
const routes: Routes = [{
  path: '',
  component: AdministrationComponent,
  children: [{
    path: 'usersDetails',
    component: UsersComponent,
  },
  {
    path: 'groupsDetails',
    component: GroupsComponent,
  },
  {
    path: 'users',
    component: UsersIndexComponent,
  },
  {
    path: 'groups',
    component: GroupsIndexComponent,
  },
  {
    path: 'profile',
    component: ProfileComponent
  }
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdministrationRoutingModule { }

export const routedComponents = [
  UsersComponent,
  GroupsComponent, ProfileComponent,
  GroupsIndexComponent, UsersIndexComponent,
  AdministrationComponent
];
