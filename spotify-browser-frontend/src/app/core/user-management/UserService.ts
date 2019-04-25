import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Paging } from '../paging';
import { User } from './model/user';
import { filter, map, tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    constructor(private httpClient: HttpClient) { }

    GetUsers(userState: number | null, emailSearchPattern: string, limit: number, offset: number): Observable<Paging<User>> {

        if (userState == null ) {
            userState = -1;
        }

        console.log('emailSearchPattern', emailSearchPattern);

        const params = new HttpParams()
            .set('userState', userState.toString())
            .set('emailSearchPattern', emailSearchPattern)
            .set('limit', limit.toString())
            .set('offset', offset.toString())
            ;

        return this.httpClient.get<Paging<User>>(`${environment.userApiReadRoot}User/GetUsers`, { params: params });
    }

    GetUsersEmailBySearchPattern(emailSearchPattern: string): Observable<string[]> {

        const params = new HttpParams()
            .set('emailSearchPattern', emailSearchPattern)
            ;

        return this.httpClient.get<string[]>(`${environment.userApiReadRoot}User/GetUsersEmailBySearchPattern`, { params: params });
    }

    ActivateUser(userId: string): Observable<any> {
        return this.httpClient.post(`${environment.userApiWriteRoot}User/ActivateUser`, { userId: userId });
    }

    DeactivateUser(userId: string): Observable<any> {
        return this.httpClient.post(`${environment.userApiWriteRoot}User/DeactivateUser`, { userId: userId });
    }

    DeleteUser(userId: string): Observable<any> {
        return this.httpClient.post(`${environment.userApiWriteRoot}User/DeleteUser`, { userId: userId });
    }
}

