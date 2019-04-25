import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Album } from './model/album';
import { Paging } from '../paging';

@Injectable({
  providedIn: 'root'
})
export class AlbumService {

  constructor(private httpClient: HttpClient) { }

  GetAlbum(id: string): Observable<Album> {

    const params = new HttpParams()
      .set('id', id);

    return this.httpClient.get<Album>(environment.apiReadRoot + 'Album/GetAlbum', { params: params });
  }

  GetArtistsAlbums(artistId: string, limit: number, offset: number): Observable<Paging<Album>> {

    const params = new HttpParams()
      .set('artistId', artistId)
      .set('limit', limit.toString())
      .set('offset', offset.toString());

    return this.httpClient.get<Paging<Album>>(environment.apiReadRoot + 'Album/GetArtistsAlbums', { params: params });
  }
}
