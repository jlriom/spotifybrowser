import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoggingService {

  constructor() { }

  log(message?: any, ...optionalParams: any[]): void {
    console.log(message, optionalParams);
    alert('Error: -> ' + message);
  }
}
