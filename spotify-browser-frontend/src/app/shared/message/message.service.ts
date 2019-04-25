import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ApplicationErrorMessageComponent } from './application-error-message/application-error-message.component';
import { SuccessResultMessageComponent } from './success-result-message/success-result-message.component';
import { ConfirmMessageComponent } from './confirm-message/confirm-message.component';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor(private modalService: NgbModal) { }

  public confirmOperation(title: string, message: string): Promise<any> {

    const modalRef = this.modalService.open(ConfirmMessageComponent);
    modalRef.componentInstance.confirmMessage = {
      title: title,
      message: message
    };

    return modalRef.result;
  }

  public showSuccessResultMessage(title: string, successResultMessage: string) {
    const modalRef = this.modalService.open(SuccessResultMessageComponent);
    modalRef.componentInstance.successMessage = {
      title: title,
      message: successResultMessage
    };
  }

  public showRemoteErrorMessage(error: HttpErrorResponse) {
    const modalRef = this.modalService.open(ApplicationErrorMessageComponent);
    modalRef.componentInstance.errorMessage = {
      id: error.error.ErrorId,
      errorType: error.status,
      message: error.error.Message,
      details: error.error.Details
    };
  }
}
