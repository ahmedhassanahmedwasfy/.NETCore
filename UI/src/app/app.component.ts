/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { NbLayoutDirectionService } from '@nebular/theme';
import { TranslateService } from '../../node_modules/@ngx-translate/core';
import { BaseService } from './@core/services/API/Base.service';
import { MessageService } from '../../node_modules/primeng/components/common/messageservice';
import { Message } from '../../node_modules/@angular/compiler/src/i18n/i18n_ast';
//import { BaseService } from './@core/services/API/Base.service';
import 'rxjs/add/operator/map';
import { RequestOptions, Http, Headers } from '@angular/http';
import { UtilityService } from './@core/services/Utility.service';
import 'rxjs/add/operator/debounceTime';

@Component({
  selector: 'ngx-app',
  template: `
  <p-progressSpinner *ngIf="loading" class="Absolute-Center">
</p-progressSpinner>

<router-outlet></router-outlet>
   <p-growl [life]="MessageLife" [(value)]="msgs"></p-growl>


   `,
  styleUrls: ['./app.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent implements OnInit {
  unsub;
  msgs: any[] = [];
  MessageLife = 5000;
  loading = false;
  constructor(
    private messageService: MessageService,
    private BaseService: BaseService,
    private UtilityService: UtilityService,
    private translate: TranslateService, private _NbLayoutDirectionService: NbLayoutDirectionService) {
    translate.setDefaultLang('en');
    this.messageService.messageObserver.subscribe(res => {

    })

    this.unsub = _NbLayoutDirectionService.onDirectionChange().subscribe(res => {
      if (res == 'ltr') {
        this.translate.use('en');
      }
      else {
        this.translate.use('ar');
      }

    })
    this.UtilityService.SpinnerChange.debounceTime(300).subscribe(res => this.loading = res)
    this.UtilityService.MessageChange.debounceTime(300).subscribe(res => {
      if (res) {
        this.msgs.push(res)
      }
    }
    )
  }

  async ngOnInit() {
    const conf = await this.BaseService.loadConfiguration();
    this.BaseService.setConfiguration(conf);
    this.MessageLife = this.BaseService.Configuration.MessageLife; 
  }
}
