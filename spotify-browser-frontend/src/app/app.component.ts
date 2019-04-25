import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from './core/auth/auth.service';
import { Router } from '@angular/router';
import { AppInsights } from 'applicationinsights-js';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: []
})
export class AppComponent implements OnInit, OnDestroy {

  constructor(
    private _authService: AuthService,
    private _router: Router) {

    if (environment.production && !AppInsights.config) {
        AppInsights.downloadAndSetup({ instrumentationKey: environment.appInsights.instrumentationKey });
    }
  }

  ngOnInit() {

    if (window.location.href.indexOf('?postLogout=true') > 0) {
      this._authService.signoutRedirectCallback().then(() => {
        const url: string = this._router.url.substring(
          0,
          this._router.url.indexOf('?')
        );
        this._router.navigateByUrl(url);
      });
    }
  }

  ngOnDestroy(): void {
  }
}
