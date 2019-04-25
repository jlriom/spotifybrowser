import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Artist } from './model/artist';

@Injectable({
  providedIn: 'root'
})
export class ArtistService {

  constructor(private httpClient: HttpClient) { }

  GetArtist(artistId: string): Observable<Artist> {

    const params = new HttpParams()
      .set('artistId', artistId);

    return this.httpClient.get<Artist>(environment.apiReadRoot + 'Artist/GetArtist', { params: params });
  }

  GetRelatedArtists(artistId: string): Observable<Artist[]> {

    const params = new HttpParams()
      .set('artistId', artistId);

    return this.httpClient.get<Artist[]>(environment.apiReadRoot + 'Artist/GetRelatedArtists', { params: params });
  }
}
