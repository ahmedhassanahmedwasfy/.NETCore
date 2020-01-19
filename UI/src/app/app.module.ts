/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, OnInit } from '@angular/core'; 
import { CoreModule } from './@core/core.module';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ThemeModule } from './@theme/theme.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap'; 
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { TranslateModule, TranslateLoader, TranslateService } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { environment } from '../environments/environment';
import {ProgressSpinnerModule} from 'primeng/progressspinner';



import {
  SocialLoginModule,
  AuthServiceConfig,
  GoogleLoginProvider,
  FacebookLoginProvider,
  LinkedinLoginProvider,
} from "angular-6-social-login"; 
import { BaseService } from './@core/services/API/Base.service';
import { MessageService } from '../../node_modules/primeng/components/common/messageservice';
import { NbLayoutDirectionService } from '../../node_modules/@nebular/theme';
import { UtilityService } from './@core/services/Utility.service';
  // import { HttpModule } from '../../node_modules/@angular/http';
 
 // Configs 
export function getAuthServiceConfigs() {
  let config = new AuthServiceConfig(
      [
        {
          id: FacebookLoginProvider.PROVIDER_ID,
          provider: new FacebookLoginProvider(environment.Facebook_AppID)
        },
        {
          id: GoogleLoginProvider.PROVIDER_ID,
          provider: new GoogleLoginProvider(environment.Google_AppID)
        },
          // {
          //   id: LinkedinLoginProvider.PROVIDER_ID,
          //   provider: new LinkedinLoginProvider("1098828800522-m2ig6bieilc3tpqvmlcpdvrpvn86q4ks.apps.googleusercontent.com")
          // },
      ]
  );
  return config;
}
@NgModule({
  declarations: [AppComponent],
  imports: [
    ProgressSpinnerModule,
    // HttpModule ,
    SocialLoginModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule, 
    AppRoutingModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
    NgbModule.forRoot(),
    ThemeModule.forRoot(),
    CoreModule.forRoot(),
  ],
  bootstrap: [AppComponent],
  providers: [MessageService,UtilityService,
    { provide: APP_BASE_HREF, useValue: '/' },{
      provide: AuthServiceConfig,
      useFactory: getAuthServiceConfigs
    }
  ],
})
export class AppModule  implements OnInit {
  constructor(
    private messageService: MessageService,
    private BaseService: BaseService,
    private translate: TranslateService, private _NbLayoutDirectionService: NbLayoutDirectionService) {
    // translate.setDefaultLang('en');
    // this.messageService.messageObserver.subscribe(res => {
       
    // })

    //   _NbLayoutDirectionService.onDirectionChange().subscribe(res => {
    //   if (res == 'ltr') {
    //     this.translate.use('en');
    //   }
    //   else {
    //     this.translate.use('ar');
    //   }

    // }) 
  }
  async ngOnInit() {
    // const conf = await this.BaseService.loadConfiguration();
    // this.BaseService.setConfiguration(conf);
  }
}
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}