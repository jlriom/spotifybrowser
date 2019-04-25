import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { MessageService } from './shared/message/message.service';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';



@Injectable()
export class ErrorMessageInterceptor implements HttpInterceptor {


  constructor(private messageService: MessageService, private ng4LoadingSpinnerService: Ng4LoadingSpinnerService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {

    this.ng4LoadingSpinnerService.show();
    return next.handle(req).pipe(
          tap(() => {}, () => {}, () => {this.ng4LoadingSpinnerService.hide(); }),
          tap(
            () => {},
            (error: HttpErrorResponse) => {
              this.ng4LoadingSpinnerService.hide();
              this.messageService.showRemoteErrorMessage(error);
            }));
  }
}
