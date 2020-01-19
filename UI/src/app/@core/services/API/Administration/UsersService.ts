import { Injectable } from '@angular/core';
import { BaseService } from '../Base.service';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
 

  constructor(private BaseService: BaseService) { }
  Get(ID) {
    return this.BaseService.GETJSON('/users/Get?ID=' + ID);
  }
  save(model: any): any {
    return this.BaseService.POSTJSON('/users/Create',model);
  }
  GetAll(): any {
    return this.BaseService.GETJSON('/users/GetAll');
     
  }
  GetAllUserTypes(): any {
    return this.BaseService.GETJSON('/UserType/Get');
     
  }
  
}
