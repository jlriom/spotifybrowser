import { User } from 'oidc-client';

export class AppUser {
  private user: User;

  constructor(user: User) {
    this.user = user;
  }

  get email(): string {
    const propertyName = 'email';
    return this.user.profile[propertyName];
  }

  get id(): string {
    const propertyName = 'sub';
    return this.user.profile[propertyName];
  }

  isLoggedIn(): boolean {
    return this.user && this.user.access_token && !this.user.expired;
  }

  getAccessToken(): string {
    return this.user ? this.user.access_token : '';
  }

  isAdmin()  {
    const admin = 'Admin';
    const propertyName = 'role';
    if (this.user &&  this.user.profile && this.user.profile[propertyName]) {
      const roles: string | string[] = this.user.profile[propertyName];

      if (typeof(roles) === 'string') {
        return roles === admin;
      } else {
        return roles.findIndex( role => role === admin) > -1;
      }
    }
    return false;
  }
}
