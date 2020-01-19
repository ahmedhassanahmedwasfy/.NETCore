import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ParamateresService {

  constructor() { }

  Encode(value) {
    return window.btoa(value);
  }

  Decode(value) {
    return window.atob(value);
  }
}
