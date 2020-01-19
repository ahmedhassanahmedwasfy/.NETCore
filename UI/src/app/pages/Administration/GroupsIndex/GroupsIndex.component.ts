import { Component, OnInit } from '@angular/core';
import { ParamateresService } from '../../../@core/services/ParamateresService';
import { ActivatedRoute } from '../../../../../node_modules/@angular/router';
import { UsersGroupsService } from '../../../@core/services/API/Administration/UsersGroupsService';
import { PrivilligesServiceService } from '../../../@core/services/API/Administration/PrivilligesService';
import { MessageService } from '../../../../../node_modules/primeng/components/common/messageservice';
import { UtilityService } from '../../../@core/services/Utility.service';
import { TranslateService } from '../../../../../node_modules/@ngx-translate/core';

@Component({
  selector: 'ngx-GroupsIndex',
  templateUrl: './GroupsIndex.component.html',
  styleUrls: ['./GroupsIndex.component.scss']
})
export class GroupsIndexComponent implements OnInit {
  groups: any[] = [];
  columns:any[]=[];
  sucess_msg;
  failed_msg;
  constructor(
    private UtilityService: UtilityService,
    private messageService: MessageService, private translate: TranslateService,
    private _usersGroupsService: UsersGroupsService, private activatedRoute: ActivatedRoute, private _paramateresService: ParamateresService
  ) {
this.columns=[
  {header:'NameEn',field:'NameEn'},
  {header:'NameAr',field:'NameAr'}
];

  }

  async ngOnInit() {
    this.UtilityService.ShowSpinner();
    this.sucess_msg = await this.translate.get('sucess_msg').toPromise();
    this.failed_msg = await this.translate.get('failed_msg').toPromise();
    try { 

       
        let res = await this._usersGroupsService.GetAll( ).toPromise() ;
        this.groups = res.data.PageModel;
       
    
    }
    catch (e) {
      this.messageService.add({ severity: 'error', summary: '', detail: this.failed_msg });

    }
    finally{
      this.UtilityService.HideSpinner();

    }

  }
  GenerateParam(id){
    return this._paramateresService.Encode(id);
  }
}
