import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserManager, User, WebStorageStateStore, Log } from 'oidc-client';
import { AuthContext } from './model/auth-context';
import { environment } from '../../../environments/environment';
import { BehaviorSubject } from 'rxjs';
import { AppUser } from './model/app-user';

@Injectable()
export class AuthService {
  private _userManager: UserManager;
  private accessToken: string;
  private appUserSubject: BehaviorSubject<AppUser> = new BehaviorSubject<AppUser>(null);
  private authContextSubject: BehaviorSubject<AuthContext> = new BehaviorSubject<AuthContext>(null);

  authContext$ = this.authContextSubject.asObservable();
  appUser$ = this.appUserSubject.asObservable();

  constructor(private httpClient: HttpClient) {
    Log.logger = console;
    const config = {
      authority: environment.stsAuthority,
      client_id: 'spotify-browser-webclient',
      redirect_uri: `${environment.clientRoot}assets/oidc-login-redirect.html`,
      // tslint:disable-next-line:max-line-length
      scope: 'openid profile spotify-browser-read-api spotify-browser-write-api spotify-browser-users-read-api spotify-browser-users-write-api',
      response_type: 'id_token token',
      post_logout_redirect_uri: `${environment.clientRoot}?postLogout=true`,
      userStore: new WebStorageStateStore({ store: window.localStorage }),
      automaticSilentRenew: true,
      silent_redirect_uri: `${environment.clientRoot}assets/silent-redirect.html`
    };
    this._userManager = new UserManager(config);
    this._userManager.getUser().then(user => {
      if (user && !user.expired) {
        const appUser = new AppUser(user);
        this.accessToken = appUser.getAccessToken();
        this.appUserSubject.next(appUser);
        this.loadSecurityContext();
      }
    });

    this._userManager.events.addUserLoaded(args => {
      this._userManager.getUser().then(user => {
        const appUser = new AppUser(user);
        this.accessToken = appUser.getAccessToken();
        this.appUserSubject.next(appUser);
        this.loadSecurityContext();
      });
    });
  }

  login(): Promise<any> {
    return this._userManager.signinRedirect();
  }

  logout(): Promise<any> {
    return this._userManager.signoutRedirect();
  }

  signoutRedirectCallback(): Promise<any> {
    return this._userManager.signoutRedirectCallback();
  }


  getAccessToken() {
    return this.accessToken;
  }

  loadSecurityContext() {
    this.httpClient.get<AuthContext>(`${environment.userApiReadRoot}Account/AuthContext`).subscribe(context => {
      this.authContextSubject.next(new AuthContext(context.userProfile, context.claims));
    });
  }
}
