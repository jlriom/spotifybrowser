import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ErrorMessage } from '../error-message';

@Component({
  selector: 'app-application-error-message',
  templateUrl: './application-error-message.component.html'
})
export class ApplicationErrorMessageComponent implements OnInit {

  readonly businessRemoteError = 400;

  @Input() errorMessage: ErrorMessage;

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit() {
  }

  close() {
    this.activeModal.close();
  }

}
