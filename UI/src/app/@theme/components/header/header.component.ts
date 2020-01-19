import { Component, Input, OnInit } from '@angular/core';

import { NbMenuService, NbSidebarService, NbSpinnerService } from '@nebular/theme';
import { UserService } from '../../../@core/data/users.service'; 
import { TranslateService } from '@ngx-translate/core';
import { TokenService } from '../../../@core/services/Token.service';

@Component({
  selector: 'ngx-header',
  styleUrls: ['./header.component.scss'],
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {


  @Input() position = 'normal';

  user: any;
  loc_Profile;Change_password;
  loc_logout;
  userMenu;
  constructor(
    private TokenService:TokenService,
    private sidebarService: NbSidebarService,
    private menuService: NbMenuService,
    private userService: UserService, 
    private translate: TranslateService,
    private spinner: NbSpinnerService) {
     

  }

  async  ngOnInit() {
    // this.userService.getUsers()
    //   .subscribe((users: any) => this.user = users.nick);
    this.user=this.TokenService.getPayload().User;
  
    this.translate.onLangChange.subscribe(res => { this.localize() })
    await this.localize();
  }
  async localize() {

    this.loc_logout = await this.translate.get('logout').toPromise()

    this.loc_Profile = await this.translate.get('Profile').toPromise()
    this.Change_password = await this.translate.get('Change_password').toPromise()
    this.userMenu = [
      { title: this.loc_Profile , link: '/pages/administration/profile'},
      { title: this.Change_password , link: '/auth/reset-password'},
       { title: this.loc_logout, link: '/auth/logout' }];

  }
  toggleSidebar(): boolean {
    this.sidebarService.toggle(true, 'menu-sidebar');
    return false;
  }

  toggleSettings(): boolean {
    this.sidebarService.toggle(false, 'settings-sidebar');
    return false;
  }

  goToHome() {
    this.menuService.navigateHome();
  }

  startSearch() { 
  }
}
