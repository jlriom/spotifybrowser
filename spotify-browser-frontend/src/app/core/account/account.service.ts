import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { RegisterUserInfo } from './model/RegisterUserInfo';
import { UnregisterUserInfo } from './model/UnregisterUserInfo';
import { ChangePasswordInfo } from './model/ChangePasswordInfo';
import { UpdateUserInfo } from './model/UpdateUserInfo';

@Injectable({
    providedIn: 'root'
})
export class AccountService {
    constructor(private httpClient: HttpClient) { }

    Register(registerUserInfo: RegisterUserInfo): Observable<any> {
        return this.httpClient.post(`${environment.userApiWriteRoot}Account/Register`, registerUserInfo);
    }

    Unregister(unregisterUserInfo: UnregisterUserInfo): Observable<any> {
        return this.httpClient.post(`${environment.userApiWriteRoot}Account/Unregister`, unregisterUserInfo);
    }

    Update(updateUserInfo: UpdateUserInfo): Observable<any> {
        return this.httpClient.post(`${environment.userApiWriteRoot}Account/Update`, updateUserInfo);
    }


    ChangePassword(changePasswordInfo: ChangePasswordInfo): Observable<any> {
        return this.httpClient.post(`${environment.userApiWriteRoot}Account/ChangePassword`, changePasswordInfo);
    }
}






