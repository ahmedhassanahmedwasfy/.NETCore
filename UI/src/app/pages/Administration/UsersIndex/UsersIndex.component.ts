import { Component, OnInit } from '@angular/core';
import { UtilityService } from '../../../@core/services/Utility.service';
import { MessageService } from '../../../../../node_modules/primeng/components/common/messageservice';
import { UsersGroupsService } from '../../../@core/services/API/Administration/UsersGroupsService';
import { TranslateService } from '../../../../../node_modules/@ngx-translate/core';
import { ActivatedRoute } from '../../../../../node_modules/@angular/router';
import { UsersService } from '../../../@core/services/API/Administration/UsersService';
import { ParamateresService } from '../../../@core/services/ParamateresService';

@Component({
  selector: 'ngx-UsersIndex',
  templateUrl: './UsersIndex.component.html',
  styleUrls: ['./UsersIndex.component.scss']
})
export class UsersIndexComponent implements OnInit {

  users: any[] = [];
  columns: any[] = [];
  sucess_msg;
  failed_msg;
  constructor(
    private UtilityService: UtilityService,
    private messageService: MessageService, private translate: TranslateService,
    private _usersService: UsersService, private activatedRoute: ActivatedRoute, private _paramateresService: ParamateresService
  ) {
    this.columns = [
      { header: 'Image', field: 'Image' },
      { header: 'Name', field: 'Name' },
      { header: 'UserName', field: 'UserName' },
      { header: 'Email', field: 'Email' },
    ];
  }
  async ngOnInit() {
    this.UtilityService.ShowSpinner();
    this.sucess_msg = await this.translate.get('sucess_msg').toPromise();
    this.failed_msg = await this.translate.get('failed_msg').toPromise();
    try {


      let res = await this._usersService.GetAll().toPromise();
      this.users = res.data.PageModel;


    }
    catch (e) {
      this.messageService.add({ severity: 'error', summary: '', detail: this.failed_msg });

    }
    finally{
      this.UtilityService.HideSpinner();

    }

  }
  GenerateParam(id) {
    return this._paramateresService.Encode(id);
  }
}
