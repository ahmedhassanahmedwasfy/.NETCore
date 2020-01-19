import { CanActivate, CanLoad, Route } from "../../../../node_modules/@angular/router";
import { TokenService } from "../services/Token.service";
import { Injectable } from "../../../../node_modules/@angular/core";
@Injectable({
    providedIn: 'root',
})
export class loggedInAuthGuard implements CanActivate, CanLoad {
    constructor(private TokenService: TokenService) {
    }
    canActivate() {
        let state = this.TokenService.verifyToken();
 
        if (state) {
            return true;
        }
        return false;
    }
    canLoad(route: Route) {
        let state = this.TokenService.verifyToken();
          
        if (state) {
            return true;
        }
        return false;
    }
}
