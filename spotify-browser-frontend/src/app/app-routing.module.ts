import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './public/home/home.component';
import { UnauthorizedComponent } from './public/unauthorized/unauthorized.component';
import { PageNotFoundComponent } from './public/page-not-found/page-not-found.component';
import { RegisterComponent } from './public/register/register.component';
import { AdminRouteGuard } from './core/admin-route.guard';
import { UserRouteGuard } from './core/user-route.guard';
import { UsersComponent } from './admin/users/users.component';
import { AlbumsSearchComponent } from './music/albums/albums-search/albums-search.component';
import { AlbumComponent } from './music/albums/album/album.component';
import { ArtistsSearchComponent } from './music/artists/artists-search/artists-search.component';
import { ArtistComponent } from './music/artists/artist/artist.component';
import { CategoryComponent } from './music/browse/category/category.component';
import { CategoriesComponent } from './music/browse/categories/categories.component';

const routes: Routes = [
    {
      path: 'admin/users', component: UsersComponent,
      canActivate: [ AdminRouteGuard ],
    },

    { path: 'albums/search', component: AlbumsSearchComponent, canActivate: [ UserRouteGuard ] },
    { path: 'albums/album/:id', component: AlbumComponent, canActivate: [ UserRouteGuard ] },

    { path: 'artists/search', component: ArtistsSearchComponent, canActivate: [ UserRouteGuard ] },
    { path: 'artists/artist/:id', component: ArtistComponent, canActivate: [ UserRouteGuard ] },

    { path: 'browse/categories', component: CategoriesComponent, canActivate: [ UserRouteGuard ] },
    { path: 'browse/category/:id', component: CategoryComponent, canActivate: [ UserRouteGuard ] },

    { path: 'unauthorized', component: UnauthorizedComponent },
    { path: 'home', component: HomeComponent },
    { path: 'register', component: RegisterComponent },

    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: '**', component: PageNotFoundComponent }
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
