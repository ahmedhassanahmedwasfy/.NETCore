import { Injectable } from '@angular/core';
import * as jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  clear()  {
    localStorage.removeItem('lcl.T');
  }

  constructor() { }
  getToken() {
    return localStorage.getItem('lcl.T');
  }
  setToken(value) {
      localStorage.setItem('lcl.T', value);
  }
  verifyToken() {
    if (this.getToken())
      return true;
  }
  getPayload() {
   return jwt_decode(this.getToken())
  }
}
