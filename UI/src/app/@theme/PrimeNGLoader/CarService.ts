import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
 

@Injectable()
export class CarService {

    constructor(private http: Http) {}

    getCarsLarge()   {
        return this.http.get('./assets/data/cars-large.json')
                     .map(res=>res.json()).toPromise() 
    }
    getPeople(){
        return this.http.get('https://randomuser.me/api/?format=json')
        .map(res=>res.json()).toPromise() 
        
    }
}