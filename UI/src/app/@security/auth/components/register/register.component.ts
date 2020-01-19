/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../../../../@core/services/API/Account.service';
import { MessageService } from '../../../../../../node_modules/primeng/components/common/messageservice';
import { TranslateService } from '../../../../../../node_modules/@ngx-translate/core';

@Component({
  selector: 'nb-register',
  styleUrls: ['./register.component.scss'],
  templateUrl: './register.component.html'
})
export class NbRegisterComponent {

  redirectDelay: number = 0;
  showMessages: any = {};
  strategy: string = '';

  submitted = false;
  errors: string[] = [];
  messages: string[] = [];
  user: any = {};

  constructor(protected accountService: AccountService, private messageService: MessageService,
    protected router: Router, private translate: TranslateService) {


  }

  async  register() {
    this.errors = this.messages = [];
    this.submitted = true;
    let result: any = await this.accountService.register({ 'User': this.user }).toPromise();
    let sucess_msg = await this.translate.get('success').toPromise();
    let failed_msg = await this.translate.get('error').toPromise();
    this.submitted = false;
    if (result.Success == true) {
      this.messageService.add({ severity: 'success', summary: sucess_msg , detail:''  });
      this.router.navigateByUrl('/auth/login');
    } else {
      this.messageService.add({ severity: 'error', summary: failed_msg, detail: result.Message });
    }
  }


}
