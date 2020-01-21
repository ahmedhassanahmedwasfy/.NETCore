import { Component, OnInit } from '@angular/core';
import { UtilityService } from '../../../@core/services/Utility.service';
import { MessageService } from '../../../../../node_modules/primeng/components/common/messageservice';
import { TranslateService } from '../../../../../node_modules/@ngx-translate/core';
import { ActivatedRoute } from '../../../../../node_modules/@angular/router';
import { ParamateresService } from '../../../@core/services/ParamateresService';
import { UsersService } from '../../../@core/services/API/Administration/UsersService';
import { PrivilligesServiceService } from '../../../@core/services/API/Administration/PrivilligesService';
import { UsersGroupsService } from '../../../@core/services/API/Administration/UsersGroupsService';
import { SelectItem } from 'primeng/api';
@Component({
  selector: 'ngx-Users',
  templateUrl: './Users.component.html',
  styleUrls: ['./Users.component.scss']
})
export class UsersComponent implements OnInit {

  source_privilliges;
  source_groups;
  ID;
  User: any;
  UserTypes: any[] = [];
  currentLang;
  constructor(
    private UtilityService: UtilityService,
    private messageService: MessageService, private translate: TranslateService,
    private UsersGroupsService: UsersGroupsService,
    private PrivilligesServiceService: PrivilligesServiceService, private _usersService: UsersService, private activatedRoute: ActivatedRoute, private _paramateresService: ParamateresService) {
    this.User.Privilliges = [];
    this.User.Groups = [];
  
} 

selectedCar: string;
async ngOnInit() {


  this.UtilityService.ShowSpinner();
  this.currentLang = this.translate.currentLang;
  this.translate.onLangChange.subscribe(res => {
    this.currentLang = this.translate.currentLang;
  })
  try {

    let res = await this.PrivilligesServiceService.Getall().toPromise();
    this.source_privilliges = res.data.PageModel;
    let _id = this.activatedRoute.snapshot.queryParams['ID'];
    let _res = await this.UsersGroupsService.GetAll().toPromise();
    this.source_groups = _res.data.PageModel;
    let _res_usertypes = await this._usersService.GetAllUserTypes().toPromise();
    this.UserTypes = _res_usertypes.data;
    if (_id) {
      this.ID = this._paramateresService.Decode(_id);
    }
    if (this.ID) {
      let _g = await this._usersService.Get(this.ID).toPromise();
      this.User = _g.data;
      if (this.User && this.User.Privilliges) {
        this.User.Privilliges.forEach(element => {
          let i = this.source_privilliges.find(c => c.ID == element.ID);
          if (i != -1) {
            this.source_privilliges.splice(i, 1);
          }
        });
      }
      if (this.User && this.User.Groups) {
        this.User.Groups.forEach(element => {
          let i = this.source_groups.find(c => c.ID == element.ID);
          if (i != -1) {
            this.source_groups.splice(i, 1);
          }
        });
      }
    }
  }
  catch (e) {
    this.UtilityService.ShowError();

  }
  finally {
    this.UtilityService.HideSpinner();

  }

}
UserType;
UserTypeChange() {
  debugger;
  this.User.UserTypeID = this.UserType.ID;
}
async save() {
  try {
    let res = await this._usersService.save(this.User).toPromise();
    this.UtilityService.ShowSuccess();

  } catch (e) {
    this.UtilityService.ShowError();

  }
}
}
