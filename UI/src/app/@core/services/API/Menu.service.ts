import { Injectable } from '@angular/core';
import { BaseService } from './Base.service';

@Injectable({
  providedIn: 'root'
})
export class MenuService {
  constructor(private BaseService: BaseService) { }
  GetMenuItems( ) {
    return this.BaseService.GETJSON('/menu/GetMenuItems');
  }
  

}
