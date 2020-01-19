/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
import { Component, Inject, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../../../../@core/services/API/Account.service';
import { UtilityService } from '../../../../@core/services/Utility.service'
import { MessageService } from '../../../../../../node_modules/primeng/components/common/messageservice';
import { NgForm } from '../../../../../../node_modules/@angular/forms';

@Component({
  selector: 'nb-reset-password-page',
  styleUrls: ['./reset-password.component.scss'],
  templateUrl: './reset-password.component.html'
})
export class NbResetPasswordComponent {

  redirectDelay: number = 0;
  showMessages: any = {};
  strategy: string = '';

  submitted = false;
  errors: string[] = [];
  messages: string[] = [];
  user: any = {};
  @ViewChild('resetPassForm') public myform: NgForm;

  constructor(
    private messageService: MessageService,
    private AccountService: AccountService, private Utilityservice: UtilityService,
    protected router: Router) {

  }

  async  resetPass() {
    this.errors = this.messages = [];
    this.submitted = true;
    this.Utilityservice.ShowSpinner();
    try {
      let res = await this.AccountService.ChangePassword(this.user).toPromise(); 
      if (res.Success ==true ) {
        this.Utilityservice.ShowSuccess();
      }

    } catch (e) {
    debugger;

      this.Utilityservice.ShowError(); 
    }
    finally {
      this.Utilityservice.HideSpinner();
      this.submitted = false;  
       this.myform.resetForm();
    }
  }}
