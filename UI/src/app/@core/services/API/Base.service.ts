import { Injectable, OnInit } from '@angular/core';

import { RequestOptions, Http, Headers } from '@angular/http';
import { HttpHeaders } from '../../../../../node_modules/@angular/common/http';
import 'rxjs/add/operator/map';
import { Observable } from '../../../../../node_modules/rxjs';
import { TokenService } from '../Token.service';


@Injectable({
  providedIn: 'root',
})
export class BaseService {
  Configuration;


  constructor(private http: Http, private _tokenService: TokenService) { }
  token() {
    return this._tokenService.getToken();
  };
  loadConfiguration() {
    return this.http.get('assets/config.json').map(res => res.json()).toPromise();
  }
  setConfiguration(conf) {
    this.Configuration = conf;
  }
  POSTJSON( url,model): Observable<any> {
    let myHeaders = new Headers();
    myHeaders.append('Content-Type', 'application/json');
    myHeaders.append('Authorization', `Bearer ${this.token()}`);
    let options = new RequestOptions({ headers: myHeaders });
    return this.http.post(this.Configuration.BaseUrl + url, model, options).map(c => c.json());
  }
  GETJSON(url): Observable<any> {

    let myHeaders = new Headers();
    myHeaders.append('Content-Type', 'application/json');
    myHeaders.append('Authorization', `Bearer ${this.token()}`);
    let options = new RequestOptions({ headers: myHeaders });
    return this.http.get(this.Configuration.BaseUrl + url, options).map(c => c.json());

  }
}

