import { Injectable } from '@angular/core';
import { BaseService } from '../Base.service';

@Injectable({
  providedIn: 'root'
})
export class PrivilligesServiceService {

  constructor(private BaseService: BaseService) { }
  Getall() {
    return this.BaseService.GETJSON('/Privilliges/Getall');
  }
}
