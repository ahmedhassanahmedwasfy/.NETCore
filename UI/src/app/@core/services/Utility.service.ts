import { Injectable } from '@angular/core';
import { BehaviorSubject } from '../../../../node_modules/rxjs';
import { MessageService } from '../../../../node_modules/primeng/components/common/messageservice';
import { TranslateService } from '@ngx-translate/core';
import { Message } from '../../../../node_modules/primeng/components/common/message';
@Injectable({
  providedIn: 'root'
})
export class UtilityService {
  private loading: boolean;
  private Message :Message ;
  SpinnerChange = new BehaviorSubject<boolean>(this.loading);
  MessageChange = new BehaviorSubject<Message>(this.Message);
  constructor(private messageService: MessageService, private translate: TranslateService) { }
  ShowSpinner() {
    this.loading = true;
    this.SpinnerChange.next(this.loading);
  }
  HideSpinner() {
    this.loading = false;
    this.SpinnerChange.next(this.loading);

  }
  async ShowSuccess(msg = 'success') {
    let success_msg;
    let res = await this.translate.get(msg).toPromise();
    success_msg = res;
    this.Message={ severity: 'success', summary: '', detail: success_msg };
    // this.messageService.add({ severity: 'success', summary: '', detail: success_msg }); 
    this.MessageChange.next(this.Message);

  }
  async ShowError(msg = 'error') {
    let error_msg;
    let res = await this.translate.get(msg).toPromise();
    error_msg = res;
    this.Message={ severity: 'error', summary: '', detail: error_msg };
    // this.messageService.add({ severity: 'error', summary: '', detail: error_msg }); 
    this.MessageChange.next(this.Message);

  }
}
