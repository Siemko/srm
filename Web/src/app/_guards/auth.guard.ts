import { LocalStorageConst } from './../_consts/local-storage.const';
import { Injectable } from '@angular/core';
import { CanActivate, Router, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import { LoginService } from '../login/login.service';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private authService: LoginService, private router: Router) {
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        if (this.authService.isLoggedIn()) {
            return true;
        }
        this.router.navigate(['/login']);
        return false;
    }

    isStarosta(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        const role = localStorage.getItem(LocalStorageConst.ROLE_NAME);
        return role === 'Starosta';
    }
}
