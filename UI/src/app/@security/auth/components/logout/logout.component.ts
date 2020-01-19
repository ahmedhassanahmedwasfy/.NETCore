/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router'; 
import { TokenService } from '../../../../@core/services/Token.service';

@Component({
  selector: 'nb-logout',
  template: `
    <div>{{'loggingOut'|translate}}</div>
  `,
})
export class NbLogoutComponent implements OnInit {

  redirectDelay: number = 0;
  strategy: string = '';

  constructor( private TokenService:TokenService,
              protected router: Router) {
 
     
  }

  ngOnInit(): void {
    this.logout(this.strategy);
  }

  logout(strategy: string): void {
    this.TokenService.clear();
    this.router.navigateByUrl('/auth/login')
  }

  
}
