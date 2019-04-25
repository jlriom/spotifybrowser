import { Component, OnInit, OnDestroy } from '@angular/core';
import { UserService } from 'src/app/core/user-management/UserService';
import { MessageService } from 'src/app/shared/message/message.service';
import { User } from 'src/app/core/user-management/model/user';
import { Paging } from 'src/app/core/paging';
import { getUserStateDescription, UserState } from 'src/app/core/user-management/model/userState';
import { AuthService } from 'src/app/core/auth/auth.service';
import { UsersSearchCriteria } from './users-search-criteria/users-search-criteria';
import { ActivatedRoute, Router } from '@angular/router';
import { AppUser } from 'src/app/core/auth/model/app-user';
import { Subscription, noop } from 'rxjs';
import { Page } from 'src/app/core/page';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html'
})
export class UsersComponent implements OnInit, OnDestroy {

  private appUserSubs: Subscription;
  appUserInSession: AppUser;

  currentPage: Page;
  pagedUsers: Paging<User>;

  usersSearchCriteria: UsersSearchCriteria =
    new UsersSearchCriteria(UsersSearchCriteria.defaultUserState, UsersSearchCriteria.defaultEmailSearchPattern);


  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService,
    private userService: UserService,
    private messageService: MessageService) { }

  ngOnInit() {
    this.route.queryParams.subscribe( queryParams => {
      this.usersSearchCriteria = new UsersSearchCriteria(
          queryParams['userState'] ||  UsersSearchCriteria.defaultUserState,
          queryParams['emailSearchPattern'] || UsersSearchCriteria.defaultEmailSearchPattern);

        this.currentPage = new Page( queryParams['page'] ||  Page.defaultPage, queryParams['limit'] ||  Page.defaultLimit );

        this.getUsers(
          this.usersSearchCriteria.userState, this.usersSearchCriteria.email, this.currentPage.limit, this.currentPage.offset);
    });

    this.appUserSubs = this.authService.appUser$.subscribe(appUser => this.appUserInSession = appUser);
  }

  ngOnDestroy(): void {
    this.appUserSubs.unsubscribe();
  }

  onUserSearchRequested(usersSearchCriteria: UsersSearchCriteria) {
    this.currentPage.page = 1;
    this.fetchQuery();
  }

  onPageChanged($event) {
    this.currentPage.page = <number>$event;
    this.fetchQuery();
  }

  getUserStateDescription(userState: number) {
    return getUserStateDescription(userState);
  }

  canBeActivated(user: User): boolean {
    return !this.isUserInSession(user)
      && (user.userState === <number>UserState.Deactive || user.userState === <number>UserState.PendingToActivate);
  }

  canBeDectivated(user: User): boolean {
    return (!this.isUserInSession(user)) && user.userState === <number>UserState.Active;
  }

  canBeDeleted(user: User): boolean {
    return !this.isUserInSession(user);
  }

  delete(user: User) {
    this.messageService
      .confirmOperation('User deletiond', `You are going to delete user with email ${user.email}.\n Do you want to continue?`)
      .then(() => {
        this.userService.DeleteUser(user.id).subscribe
          (() => {
            this.getUsers(
              this.usersSearchCriteria.userState, this.usersSearchCriteria.email,
              this.currentPage.limit, this.currentPage.offset);
            this.messageService.showSuccessResultMessage('Selected user deleted succesfully!', '');
          });
      }).catch(noop);
  }

  activate(user: User) {
    this.messageService
      .confirmOperation('User activation', `You are going to activate user with email ${user.email}.\n Do you want to continue?`)
      .then(() => {
        this.userService.ActivateUser(user.id).subscribe
          (() => {
            this.getUsers(
              this.usersSearchCriteria.userState, this.usersSearchCriteria.email,
              this.currentPage.limit, this.currentPage.offset);
            this.messageService.showSuccessResultMessage('Selected user activated succesfully!', '');
          });
      }).catch(noop);
  }

  deactivate(user: User) {
    this.messageService
      .confirmOperation('User deactivation', `You are going to deactivate user with email ${user.email}.\n Do you want to continue?`)
      .then(() => {
        this.userService.DeactivateUser(user.id).subscribe
          (() => {
            this.getUsers(
              this.usersSearchCriteria.userState, this.usersSearchCriteria.email,
              this.currentPage.limit, this.currentPage.offset);
            this.messageService.showSuccessResultMessage('Selected user deactivated succesfully!', '');
          });
      }).catch(noop);
  }

  private fetchQuery() {
    this.router.navigate(['/admin/users'], {
    queryParams: {
      emailSearchPattern: this.usersSearchCriteria.email,
      limit: this.currentPage.limit,
      page: this.currentPage.page,
      userState: this.usersSearchCriteria.userState
    }
    });
  }

  private getUsers(userState: number | null, emailSearchPattern: string, limit: number, offset: number) {
    this.userService.GetUsers(userState, emailSearchPattern, limit, offset).subscribe(pagedUsers => {
      this.pagedUsers = pagedUsers;
    });
  }

  private isUserInSession(user: User): boolean {
    return user.email === this.appUserInSession.email;
  }
}
