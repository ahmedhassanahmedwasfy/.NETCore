/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
import { Component, OnDestroy } from '@angular/core';
import { Location } from '@angular/common';
 
import { takeWhile } from 'rxjs/operators';

@Component({
  selector: 'nb-auth',
  styleUrls: ['./auth.component.scss'],
  templateUrl:'./auth.component.html'  
 
   
})
export class NbAuthComponent implements OnDestroy {

  private alive = true;

  subscription: any;

  authenticated: boolean = false;
  token: string = '';

  // showcase of how to use the onAuthenticationChange method
  constructor(  protected location: Location) {
 
  }

  back() {
    this.location.back();
    return false;
  }

  ngOnDestroy(): void {
    this.alive = false;
  }
}
