 
import { Component, Inject, ViewChild } from '@angular/core';
import { Router } from '@angular/router'; 
import { NgForm } from '../../../../../../node_modules/@angular/forms';
import { AccountService } from '../../../../@core/services/API/Account.service';
import { UtilityService } from '../../../../@core/services/Utility.service';
@Component({
  selector: 'nb-request-password-page',
  styleUrls: ['./request-password.component.scss'],
  templateUrl: './request-password.component.html' 
})
export class NbRequestPasswordComponent {

  redirectDelay: number = 0;
  showMessages: any = {};
  strategy: string = '';

  submitted = false;
  errors: string[] = [];
  messages: string[] = [];
  user: any = {};
  @ViewChild('requestPassForm') public myform: NgForm;

  constructor(
     
    private AccountService: AccountService, private Utilityservice: UtilityService,
    protected router: Router) {

  }

  async  ForgotPassword() {
    this.errors = this.messages = [];
    this.submitted = true;
    this.Utilityservice.ShowSpinner();
    try {
      let res = await this.AccountService.ForgotPassword(this.user).toPromise(); 
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
  }
}
 