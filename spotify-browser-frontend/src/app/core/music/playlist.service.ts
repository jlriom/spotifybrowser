import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { PlayList } from './model/playlist';
import { Paging } from '../paging';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PlaylistService {

  constructor(private httpClient: HttpClient) { }

  GetCategoryPlaylists(categoryId: string, limit: number = 20, offset: number = 0): Observable<Paging<PlayList>> {
    const params = new HttpParams()
      .set('categoryId', categoryId)
      .set('limit', limit.toString())
      .set('offset', offset.toString());

    return this.httpClient.get<Paging<PlayList>>(environment.apiReadRoot + 'Playlist/GetCategoryPlaylists', { params: params });
  }

  GetPlaylist(playlistId: string): Observable<PlayList> {
    const params = new HttpParams()
      .set('playlistId', playlistId);

    return this.httpClient.get<PlayList>(environment.apiReadRoot + 'Playlist/GetPlaylist', { params: params });
  }
}
