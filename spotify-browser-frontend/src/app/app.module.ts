import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Ng4LoadingSpinnerModule, Ng4LoadingSpinnerService } from 'ng4-loading-spinner';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './public/home/home.component';
import { UnauthorizedComponent } from './public/unauthorized/unauthorized.component';
import { PageNotFoundComponent } from './public/page-not-found/page-not-found.component';

import { LayoutComponent } from './shared/layout/layout.component';
import { HeaderComponent } from './shared/header/header.component';
import { FooterComponent } from './shared/footer/footer.component';

import { ErrorMessageInterceptor } from './error-rmessage.interceptor';

import { ProfileEditComponent } from './profile/profile-edit/profile-edit.component';
import { ProfileChangePasswordComponent } from './profile/profile-change-password/profile-change-password.component';
import { RegisterComponent } from './public/register/register.component';
import { ApplicationErrorMessageComponent } from './shared/message/application-error-message/application-error-message.component';
import { SuccessResultMessageComponent } from './shared/message/success-result-message/success-result-message.component';
import { ConfirmMessageComponent } from './shared/message/confirm-message/confirm-message.component';
import { ConfirmEqualValidatorDirective } from './shared/confirm-equal-validator';
import { PlayListTracksComponent } from './music/browse/play-list-tracks/play-list-tracks.component';
import { GlobalErrorHandler } from './core/global-error-handler.service';
import { UsersComponent } from './admin/users/users.component';
import { UsersSearchCriteriaComponent } from './admin/users/users-search-criteria/users-search-criteria.component';
import { AlbumsSearchComponent } from './music/albums/albums-search/albums-search.component';
import { AlbumComponent } from './music/albums/album/album.component';
import { ArtistsSearchComponent } from './music/artists/artists-search/artists-search.component';
import { ArtistComponent } from './music/artists/artist/artist.component';
import { AlbumTracksComponent } from './music/artists/album-tracks/album-tracks.component';
import { CategoriesComponent } from './music/browse/categories/categories.component';
import { CategoryComponent } from './music/browse/category/category.component';
import { AlbumDetailsComponent } from './shared/album-details/album-details.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from './core/auth/auth.service';
import { UserRouteGuard } from './core/user-route.guard';
import { AdminRouteGuard } from './core/admin-route.guard';
import { LogInterceptor } from './core/http-interceptors/log.interceptor';
import { AuthInterceptor } from './core/http-interceptors/auth.interceptor';
import { ArtistDetailsComponent } from './music/artists/artist/artist-details/artist-details.component';
import { ArtistAlbumsComponent } from './music/artists/artist/artist-albums/artist-albums.component';
import { ArtistRelatedArtistsComponent } from './music/artists/artist/artist-related-artists/artist-related-artists.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UnauthorizedComponent,
    PageNotFoundComponent,
    LayoutComponent,
    HeaderComponent,
    FooterComponent,
    ProfileEditComponent,
    RegisterComponent,
    ProfileChangePasswordComponent,
    SuccessResultMessageComponent,
    ApplicationErrorMessageComponent,
    ConfirmMessageComponent,
    PlayListTracksComponent,
    ConfirmEqualValidatorDirective,

    UsersComponent,
    UsersSearchCriteriaComponent,

    AlbumsSearchComponent,
    AlbumComponent,

    ArtistsSearchComponent,
    ArtistComponent,
    AlbumTracksComponent,

    CategoriesComponent,
    CategoryComponent,

    AlbumDetailsComponent,

    ArtistDetailsComponent,
    ArtistAlbumsComponent,
    ArtistRelatedArtistsComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    Ng4LoadingSpinnerModule,
    NgbModule,
    AppRoutingModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorMessageInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: LogInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: ErrorHandler,  useClass: GlobalErrorHandler },
    AuthService,
    UserRouteGuard,
    AdminRouteGuard,
    Ng4LoadingSpinnerService
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    SuccessResultMessageComponent,
    ApplicationErrorMessageComponent,
    ConfirmMessageComponent,
    ProfileEditComponent,
    RegisterComponent,
    ProfileChangePasswordComponent,
    PlayListTracksComponent,
    AlbumTracksComponent
  ]
})
export class AppModule { }
