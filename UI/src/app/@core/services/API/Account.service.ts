import { Injectable } from '@angular/core';
import { BaseService } from './Base.service';

@Injectable()
export class AccountService {
  
  
  constructor(private BaseService: BaseService) { }
    login(model) {
    return   this.BaseService.POSTJSON('/account/Login',model);
  }
  register(model)  {
    return   this.BaseService.POSTJSON( '/account/register',model);
 
  }
  ChangePassword(model)  {
    return   this.BaseService.POSTJSON( '/account/ChangePassword',model);
 
  }
  ForgotPassword(model)  {
    return   this.BaseService.POSTJSON( '/account/ForgotPassword',model);
 
  }
}
