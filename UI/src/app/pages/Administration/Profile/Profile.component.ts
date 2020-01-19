import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProfileService } from '../../../@core/services/API/Profile.service';
import { UtilityService } from '../../../@core/services/Utility.service';
import { MessageService } from '../../../../../node_modules/primeng/components/common/messageservice';
import { TranslateService } from '../../../../../node_modules/@ngx-translate/core';


@Component({
  selector: 'ngx-Profile',
  templateUrl: './Profile.component.html',
  styleUrls: ['./Profile.component.scss']
})
export class ProfileComponent implements OnInit {


  redirectDelay: number = 0;
  showMessages: any = {};
  strategy: string = '';
  sucess_msg;
  failed_msg;
  submitted = false;
  errors: string[] = [];
  messages: string[] = [];
  user: any = {};

  constructor(private translate: TranslateService, private ProfileService: ProfileService, private messageService: MessageService, private UtilityService: UtilityService) {

  }

  async ngOnInit() {
    this.sucess_msg = await this.translate.get('sucess_msg').toPromise();
    this.failed_msg = await this.translate.get('failed_msg').toPromise();
    this.loadProfile()
  }
  ProfileImageChange(event) {
    let fileList: FileList = event.target.files;
    if (fileList.length > 0) {
      let file: File = fileList[0];
      var reader = new FileReader();

      reader.addEventListener("load", () => {
        this.user.Image = reader.result;
      }, false);

      if (file) {
        reader.readAsDataURL(file);
      }

    }
  }
  async  updateProfile() {
    debugger;
    this.UtilityService.ShowSpinner();

    try {
      this.ProfileService.UpdateProfile(this.user).toPromise();
      this.UtilityService.ShowSuccess();

    }
    catch (e) {
      this.UtilityService.ShowError(); 

    }
    finally {
      this.UtilityService.HideSpinner();

    }
  }
  async  loadProfile() {
    this.UtilityService.ShowSpinner();

    try {
      let _res = await this.ProfileService.LoadProfile().toPromise();
      this.user = _res.data;
      // this.messageService.add({ severity: 'error', summary: '', detail: this.sucess_msg });

    }
    catch (e) {
      this.messageService.add({ severity: 'error', summary: '', detail: this.failed_msg });

    }
    finally {
      this.UtilityService.HideSpinner();

    }
  }
}
