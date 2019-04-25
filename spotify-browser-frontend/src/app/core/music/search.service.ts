import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Paging } from '../paging';
import { Artist } from './model/artist';
import { Album } from './model/album';
import { Track } from './model/track';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  constructor(private httpClient: HttpClient) { }

  SearchArtists(q: string, limit: number, offset: number): Observable<Paging<Artist>> {

    const params = new HttpParams()
      .set('q', q)
      .set('limit', limit.toString())
      .set('offset', offset.toString());

    return this.httpClient.get<Paging<Artist>>(environment.apiReadRoot + 'Search/SearchArtists', { params: params });
  }

  SearchAlbums(q: string, limit: number, offset: number): Observable<Paging<Album>> {

    const params = new HttpParams()
      .set('q', q)
      .set('limit', limit.toString())
      .set('offset', offset.toString());

    return this.httpClient.get<Paging<Album>>(environment.apiReadRoot + 'Search/SearchAlbums', { params: params });
  }

  SearchTracks(q: string, limit: number, offset: number): Observable<Paging<Track>> {

    const params = new HttpParams()
      .set('q', q)
      .set('limit', limit.toString())
      .set('offset', offset.toString());

    return this.httpClient.get<Paging<Track>>(environment.apiReadRoot + 'Search/SearchTracks', { params: params });
  }
}
