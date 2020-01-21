import { Component, OnInit } from '@angular/core';
import { CarService } from '../../../@theme/PrimeNGLoader/CarService';
import { ActivatedRoute } from '../../../../../node_modules/@angular/router';
import { ParamateresService } from '../../../@core/services/ParamateresService';
import { UsersGroupsService } from '../../../@core/services/API/Administration/UsersGroupsService';
import { PrivilligesServiceService } from '../../../@core/services/API/Administration/PrivilligesService';
import { MessageService } from '../../../../../node_modules/primeng/components/common/messageservice';
import { TranslateService } from '../../../../../node_modules/@ngx-translate/core';
import { UtilityService } from '../../../@core/services/Utility.service';

@Component({
  selector: 'ngx-Groups',
  templateUrl: './Groups.component.html',
  styleUrls: ['./Groups.component.scss']
})
export class GroupsComponent implements OnInit {
  source;
  ID;
  Group: any;
  sucess_msg;
  failed_msg;
  constructor(
    private UtilityService: UtilityService,
    private messageService: MessageService, private translate: TranslateService,
    private PrivilligesServiceService: PrivilligesServiceService, private _usersGroupsService: UsersGroupsService, private activatedRoute: ActivatedRoute, private _paramateresService: ParamateresService) {
    this.Group.Privilliges = [] ;
  }

  async ngOnInit() {
    this.UtilityService.ShowSpinner();
    this.sucess_msg = await this.translate.get('sucess_msg').toPromise();
    this.failed_msg = await this.translate.get('failed_msg').toPromise();
    try {

      let res = await this.PrivilligesServiceService.Getall().toPromise();
      this.source = res.data.PageModel;
      let _id = this.activatedRoute.snapshot.queryParams['ID'];


      if (_id) {
        this.ID = this._paramateresService.Decode(_id);
      }
      if (this.ID) {
        let _g = await this._usersGroupsService.Get(this.ID).toPromise();
        this.Group = _g.data;
        if (this.Group && this.Group.Privilliges) {
          this.Group.Privilliges.forEach(element => {
            let i = this.source.find(c => c.ID == element.ID);
            if (i != -1) {
              this.source.splice(i, 1);
            }
          });
        }
      }
    }
    catch (e) {
      this.messageService.add({ severity: 'error', summary: '', detail: this.failed_msg });

    }
    finally{
      this.UtilityService.HideSpinner();

    }
  }

  async save() {
    try {
      let res = await this._usersGroupsService.save(this.Group).toPromise();
      this.messageService.add({ severity: 'success', summary: '', detail: this.sucess_msg });

    } catch (e) {
      this.messageService.add({ severity: 'error', summary: '', detail: this.failed_msg });

    }
  }
}
