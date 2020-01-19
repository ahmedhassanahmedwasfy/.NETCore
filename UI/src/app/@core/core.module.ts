import { ModuleWithProviders, NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { of as observableOf } from 'rxjs';

import { throwIfAlreadyLoaded } from './module-import-guard';
import { DataModule } from './data/data.module';
 import { NbAuthModule } from '../@security/auth/auth.module';
import { AccountService } from './services/API/Account.service';
import { BaseService } from './services/API/Base.service';
import { StateService } from './data/state.service';
import { UserService } from './data/users.service';
 

const Services=[AccountService,BaseService,StateService,UserService];
 
 
@NgModule({
  imports: [
    CommonModule,DataModule
  ],
  exports: [
   NbAuthModule,
  ],
  declarations: [],
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }

  static forRoot(): ModuleWithProviders {
    return <ModuleWithProviders>{
      ngModule: CoreModule,
      providers: [
        ...Services,
      ],
    };
  }
}
