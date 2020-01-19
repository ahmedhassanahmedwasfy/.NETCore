/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import {
  AuthService,
  FacebookLoginProvider,
  GoogleLoginProvider,
  LinkedinLoginProvider
} from 'angular-6-social-login';
import { TranslateService } from '@ngx-translate/core';
import { AccountService } from '../../../../@core/services/API/Account.service';
import { MessageService } from '../../../../../../node_modules/primeng/components/common/messageservice';
import { TokenService } from '../../../../@core/services/Token.service';
// import { AccountService } from '../../../../@core/services/API/Account.service';

// import { MessageService } from '../../../../../../node_modules/primeng/components/common/messageservice';

@Component({
  selector: 'nb-login',
  templateUrl: './login.component.html',
})
export class NbLoginComponent {

  errors: any[] = [];
  messages: any[] = [];
  user: any = {};
  submitted: boolean = false;
  redirect_timeout = 1500;
  redirect_URL = '/Dashboard'
  constructor(
    private TokenService: TokenService,
    protected accountService: AccountService,
    private messageService: MessageService,
    protected router: Router,
    private socialAuthService: AuthService,
    private translate: TranslateService) {


  }
  public async socialSignIn(event, socialPlatform: string) {
    try {
      event.preventDefault();
      let socialPlatformProvider;
      if (socialPlatform == "facebook") {
        socialPlatformProvider = FacebookLoginProvider.PROVIDER_ID;
      } else if (socialPlatform == "google") {
        socialPlatformProvider = GoogleLoginProvider.PROVIDER_ID;
      } else if (socialPlatform == "linkedin") {
        socialPlatformProvider = LinkedinLoginProvider.PROVIDER_ID;
      }

      let userData = await this.socialAuthService.signIn(socialPlatformProvider);
      
      this.user.Email = userData.email;
      this.user.Name = userData.name;
      this.user.Image = userData.image;
      let IsThirdParty = true;
      this.login(IsThirdParty);
    }
    catch{
    }
  }

  async login(IsThirdParty = false) {
    this.user.IsThirdParty = IsThirdParty;
    this.errors = [];
    this.messages = [];
    this.submitted = true;
    let result: any = await this.accountService.login(this.user).toPromise();
    let sucess_msg = await this.translate.get('sucess_msg_login').toPromise();
    let failed_msg = await this.translate.get('failed_msg_login').toPromise();

    this.submitted = false;
    
    if (result.Success == true && result.data) {
      let _token = result.data;
      this.TokenService.setToken(_token);
      this.messageService.add({ severity: 'success', summary: '', detail: sucess_msg });
      this.router.navigateByUrl(this.redirect_URL);
      // setTimeout(() => {
      //   return this.router.navigateByUrl(this.redirect_URL);
      // }, 100);
    }
    else {
       
      this.messageService.add({ severity: 'error', summary: '', detail: failed_msg });
    }
  }
}
