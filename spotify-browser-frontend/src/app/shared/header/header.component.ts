import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from 'src/app/core/auth/auth.service';

import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RegisterComponent } from 'src/app/public/register/register.component';
import { ProfileEditComponent } from 'src/app/profile/profile-edit/profile-edit.component';
import { ProfileChangePasswordComponent } from 'src/app/profile/profile-change-password/profile-change-password.component';
import { MessageService } from '../message/message.service';
import { Subscription } from 'rxjs';
import { AppUser } from 'src/app/core/auth/model/app-user';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent implements OnInit, OnDestroy  {

  private appUserSubs: Subscription;
  appUserInSession: AppUser;

  constructor(private authService: AuthService, private messageService: MessageService, private modalService: NgbModal) { }

  ngOnInit() {
    this.appUserSubs = this.authService.appUser$.subscribe(appUser => this.appUserInSession = appUser);
  }

  login() {
    this.authService.login();
  }

  logout() {
    this.messageService.confirmOperation('Log out', 'You are going to log out from the application.\n Do you want to continue?')
      .then(() => {
        this.authService.logout();
      }).catch(() => void (0));
  }

  isLoggedIn() {
    return this.appUserInSession && this.appUserInSession.isLoggedIn();
  }

  isAdmin(): boolean {
    return this.appUserInSession && this.appUserInSession.isLoggedIn() && this.appUserInSession.isAdmin();
  }

  UserName(): string {
    return this.appUserInSession && this.appUserInSession.email;
  }


  myprofile() {
    this.modalService.open(ProfileEditComponent);
  }

  changePassword() {
    this.modalService.open(ProfileChangePasswordComponent);
  }

  register() {
    this.modalService.open(RegisterComponent);
  }

  ngOnDestroy(): void {
    this.appUserSubs.unsubscribe();
  }
}
