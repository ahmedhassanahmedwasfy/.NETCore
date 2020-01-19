import { Component, OnInit } from '@angular/core';

import { MENU_ITEMS } from './pages-menu';
import { MenuService } from '../@core/services/API/Menu.service';
import { UtilityService } from '../@core/services/Utility.service';
import { TranslateService } from '../../../node_modules/@ngx-translate/core';

@Component({
  selector: 'ngx-pages',
  template: `
    <ngx-sample-layout>
      <nb-menu [items]="menu"></nb-menu>
      <router-outlet></router-outlet>
    </ngx-sample-layout>
  `,
})
export class PagesComponent implements OnInit {
  menu: any[] = [];
  srcmenu: any[] = [];
  currentlang;
  constructor(private translate: TranslateService, private MenuService: MenuService, private UtitlityService: UtilityService) { }
  async ngOnInit() {
    this.currentlang = this.translate.currentLang;
    this.translate.onLangChange.subscribe(res => {
      debugger;
      this.currentlang = res.lang;
      this.fillMenu();
    })
    this.UtitlityService.ShowSpinner();
    try {
      let res = await this.MenuService.GetMenuItems().toPromise();
      this.srcmenu = res.data;
      this.fillMenu();
    }
    catch (e) {
      this.UtitlityService.ShowError();
    }
    finally {
      this.UtitlityService.HideSpinner();
    }
  }
  fillMenu() {
    this.menu = this.srcmenu.map(c => {
    this.getTitledItem(c);
      return c;
    });
  }
  getTitledItem(c) {
    c.title = this.gettitle(c);
    if(c.children){
      c.children=  c.children.map(res=>{
        return this.getTitledItem(res);
      })
    }
    return c;
  }
  gettitle(item) {
    return this.currentlang == 'en' ? item.NameEn : item.NameAr
  }
   
}
