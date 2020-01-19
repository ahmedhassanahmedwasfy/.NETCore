import { Injectable } from '@angular/core';
import { BaseService } from '../Base.service';

@Injectable({
  providedIn: 'root'
})
export class UsersGroupsService {
 

  constructor(private BaseService: BaseService) { }
  Get(ID) {
    return this.BaseService.GETJSON('/Groups/Get?ID=' + ID);
  }
  save(model: any): any {
    return this.BaseService.POSTJSON('/Groups/Create',model);
  }
  GetAll(): any {
    return this.BaseService.GETJSON('/Groups/GetAll');
     
  }
 
}
