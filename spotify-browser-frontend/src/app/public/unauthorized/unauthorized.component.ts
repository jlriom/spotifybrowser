import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../core/auth/auth.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-unauthorized',
    templateUrl: 'unauthorized.component.html'
})

export class UnauthorizedComponent implements OnInit {
    constructor(private _authService: AuthService, private router: Router) { }

    ngOnInit() { }

    logout() {
        this.router.navigateByUrl('/');
        // this._authService.logout().then ( r => this.router.navigateByUrl('/'));
    }
}
