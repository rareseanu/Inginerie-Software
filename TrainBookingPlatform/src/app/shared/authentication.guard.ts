import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthenticationService } from '../shared/authentication.service'


@Injectable({providedIn: 'root'})
export class AuthenticationGuard implements CanActivate {
    constructor(
        private router: Router,
        private authenticationService: AuthenticationService
    ) {}

    async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        await this.authenticationService.refreshToken().toPromise();
        const currentUser = this.authenticationService.getCurrentUser;

        if (currentUser) {
            if (route.data['role'] && route.data['role'].indexOf(currentUser.role) > -1) {
                return true;
            }
            this.router.navigate(['/']);
            console.log(currentUser.role);
            return false;
        }

        this.router.navigate(['login']);
        return false;
    }
}