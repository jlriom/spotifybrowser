import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from '../../core/auth/auth.service';
import { AccountService } from '../../core/account/account.service';
import { MessageService } from '../../shared/message/message.service';
import { NgForm, AbstractControl } from '@angular/forms';
import { Subscription } from 'rxjs';
import { AppUser } from 'src/app/core/auth/model/app-user';

@Component({
  selector: 'app-profile-change-password',
  templateUrl: './profile-change-password.component.html'
})
export class ProfileChangePasswordComponent implements OnInit, OnDestroy {

  private appUserSubs: Subscription;
  appUserInSession: AppUser;

  currentPassword = '';
  newPassword = '';
  confirmNewPassword = '';

  constructor(
    public authService: AuthService,
    public accountService: AccountService,
    public messageService: MessageService,
    public activeModal: NgbActiveModal) {}

  ngOnInit() {
    this.appUserSubs = this.authService.appUser$.subscribe(appUser => this.appUserInSession = appUser);
  }

  dismiss() {
    this.activeModal.dismiss();
  }

  passwordChanged() {
    this.confirmNewPassword = '';
  }

  changePassword(changePasswordForm: NgForm) {
    if (changePasswordForm.valid) {
      this.messageService.confirmOperation('Change my password', 'You are going to update your password.\n Do you want to continue?')
      .then(() => {
        this.accountService.ChangePassword({
          userId: this.appUserInSession.id,
          oldPassword: this.currentPassword,
          newPassword: this.newPassword,
          confirmNewPassword: this.confirmNewPassword
        }).subscribe
        ( () => {
          this.messageService.showSuccessResultMessage('Change password', 'Operation performed successfully!');
          this.activeModal.close();
        });
      })
      .catch( () => void(0));
    }
  }

  isNotValidControl(control: AbstractControl): boolean {
    return control.dirty && !control.valid;
  }

  ngOnDestroy(): void {
    this.appUserSubs.unsubscribe();
  }
}
