import { Injectable } from '@angular/core';
import { CanActivate, Router, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import { LocalStorageConst } from '../_consts/local-storage.const';

@Injectable()
export class RoleGuard implements CanActivate {

    constructor(private router: Router) {
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        let roles: string[] = route.data.roles;
        var role = localStorage.getItem(LocalStorageConst.ROLE_NAME);
        role = role.toLowerCase();

        if (!roles || !roles.length)
            return true;

        roles = roles.map(r => r.toLowerCase())
        if (roles.indexOf(role) > -1)
            return true;

        this.router.navigate(['/home/profile']);
        return false;
    }
}