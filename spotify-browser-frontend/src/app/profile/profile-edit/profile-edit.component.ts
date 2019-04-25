import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from '../../core/auth/auth.service';
import { AccountService } from '../../core/account/account.service';
import { MessageService } from '../../shared/message/message.service';
import { NgForm, AbstractControl } from '@angular/forms';
import { Subscription } from 'rxjs';
import { AppUser } from 'src/app/core/auth/model/app-user';

@Component({
  selector: 'app-profile-edit',
  templateUrl: './profile-edit.component.html'
})
export class ProfileEditComponent implements OnInit, OnDestroy {

  private appUserSubs: Subscription;
  appUserInSession: AppUser;
  private appUserProfileSubs: Subscription;

  firstName: string;
  lastName: string;

  constructor(
    public authService: AuthService,
    public accountService: AccountService,
    public messageService: MessageService,
    public activeModal: NgbActiveModal) { }


  get email(): string {
    return this.appUserInSession.email;
  }

  get isUnregisterAllowed(): boolean {
    return !this.appUserInSession.isAdmin();
  }

  ngOnInit() {
    this.appUserSubs = this.authService.appUser$.subscribe(appUser => this.appUserInSession = appUser);
    this.appUserProfileSubs = this.authService.authContext$.subscribe(authContext => {
      this.firstName = authContext.userProfile.firstName;
      this.lastName = authContext.userProfile.lastName;
    });
  }

  dismiss() {
    this.activeModal.dismiss();
  }

  unregister() {
    this.messageService.confirmOperation('Unregister me', 'You are going to unregister your user.\n Do you want to continue?')
      .then(() => {
        this.accountService.Unregister({
          userId: this.appUserInSession.id
        }).subscribe
          (() => {
            this.messageService.showSuccessResultMessage('User unregistration', 'Operation performed successfully!');
            this.authService.logout();
          });
      }).catch(() => void (0));
  }

  saveMyProfile(myProfileForm: NgForm) {
    if (myProfileForm.valid) {
      this.messageService.confirmOperation('My profile', 'You are going to modify your profile.\n Do you want to continue?')
      .then(() => {
        this.accountService.Update({
          userId: this.appUserInSession.id, firstName: this.firstName, lastName: this.lastName
        }).subscribe
          (() => {
            this.authService.loadSecurityContext();
            this.messageService.showSuccessResultMessage('User modification', 'Operation performed successfully!');
            this.activeModal.close('Accept Register');
          });
      }).catch(() => void (0));
    }
  }

  isNotValidControl(control: AbstractControl): boolean {
    return control.dirty && !control.valid;
  }

  ngOnDestroy(): void {
    this.appUserSubs.unsubscribe();
    this.appUserProfileSubs.unsubscribe();
  }
}
