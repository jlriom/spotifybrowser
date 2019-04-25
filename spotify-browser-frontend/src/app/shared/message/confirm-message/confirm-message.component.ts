import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmMessage } from '../confirm-message';

@Component({
  selector: 'app-confirm-message.component',
  templateUrl: './confirm-message.component.html'
})
export class ConfirmMessageComponent implements OnInit {

  @Input() confirmMessage: ConfirmMessage;

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit() {
  }

  dismiss() {
    this.activeModal.dismiss();
  }


  close() {
    this.activeModal.close();
  }

}
