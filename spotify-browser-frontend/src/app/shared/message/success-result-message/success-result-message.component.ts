import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { SuccessMessage } from '../success-message';

@Component({
  selector: 'app-success-result-message',
  templateUrl: './success-result-message.component.html'
})
export class SuccessResultMessageComponent implements OnInit {

  @Input() successMessage: SuccessMessage;

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit() {
  }

  close() {
    this.activeModal.close();
  }

}
