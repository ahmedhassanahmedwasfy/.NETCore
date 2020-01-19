import { Injectable } from '@angular/core';
import { BaseService } from './Base.service';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  constructor(private BaseService: BaseService) { }
  UpdateProfile(model) {
    return this.BaseService.POSTJSON('/profile/update', model);
  }
  LoadProfile( ) {
    return this.BaseService.GETJSON('/profile/load');

  }

}
