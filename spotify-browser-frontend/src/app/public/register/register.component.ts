import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { AccountService } from 'src/app/core/account/account.service';
import { MessageService } from 'src/app/shared/message/message.service';
import { RegisterInfo } from './register-info';
import { NgForm, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {

  registerInfo = new RegisterInfo();

  constructor(
    private activeModal: NgbActiveModal,
    private accountService: AccountService,
    private messageService: MessageService ) {}

  ngOnInit() {
  }

  dismiss() {
    this.activeModal.dismiss();
  }

  passwordChanged() {
    this.registerInfo.confirmPassword = '';
  }

  register(registerForm: NgForm) {
    if (registerForm.valid) {
      this.messageService.confirmOperation('Register me', 'You are going to register int the application.\n Do you want continue?')
        .then( () =>  {
          this.accountService.Register(this.registerInfo).subscribe
          ( () => {
                  this.messageService.showSuccessResultMessage('User registration', 'Operation performed successfully!');
                  this.activeModal.close('Accept Register');
          });
        })
        .catch ( () => void(0) );
    }
  }

  isNotValidControl(control: AbstractControl): boolean {
    return control.dirty && !control.valid;
  }
}
