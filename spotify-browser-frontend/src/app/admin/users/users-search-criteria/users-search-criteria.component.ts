import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UsersSearchCriteria } from './users-search-criteria';
import { UserState, getUserStateDescription } from 'src/app/core/user-management/model/userState';
import { debounceTime, distinctUntilChanged, map, tap, switchMap, catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { UserService } from 'src/app/core/user-management/UserService';

@Component({
  selector: 'app-users-search-criteria',
  templateUrl: './users-search-criteria.component.html'
})
export class UsersSearchCriteriaComponent implements OnInit {
  model: any;
  searching = false;
  searchFailed = false;

  @Input()
  usersSearchCriteria: UsersSearchCriteria; // = new UsersSearchCriteria(-1, '');

  @Output()
  userSearchRequested: EventEmitter<UsersSearchCriteria> = new EventEmitter<UsersSearchCriteria>();

  constructor(private userService: UserService) { }

  ngOnInit() {
  }

  searchNameOfUsers = (text$: Observable<string>) =>
    text$.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      tap(() => this.searching = true),
      switchMap(term =>
        this.userService.GetUsersEmailBySearchPattern(term).pipe(
          tap(() => this.searchFailed = false),
          catchError(() => {
            this.searchFailed = true;
            return of([]);
          }))
      ),
      tap(() => this.searching = false)
    )

  searchUsers() {
    this.userSearchRequested.emit(this.usersSearchCriteria);
  }

  clear(searchUsersCriteriaForm: NgForm) {
    searchUsersCriteriaForm.resetForm();
    this.usersSearchCriteria = new UsersSearchCriteria(UsersSearchCriteria.defaultUserState, UsersSearchCriteria.defaultEmailSearchPattern);
  }

  GetUserStates(): UserState[] {
    return [UserState.Active, UserState.Deactive, UserState.PendingToActivate, UserState.Unregistered];
  }

  GetUserStateDescription(userState: number) {
    return getUserStateDescription(userState);
  }


}
