import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Track } from './model/track';
import { Paging } from '../paging';

@Injectable({
  providedIn: 'root'
})
export class TrackService {

  constructor(private httpClient: HttpClient) { }

  GetAlbumTracks(albumId: string, limit: number = 50, offset: number = 0): Observable<Paging<Track>> {

    const params = new HttpParams()
      .set('albumId', albumId)
      .set('limit', limit.toString())
      .set('offset', offset.toString());

    return this.httpClient.get<Paging<Track>>(environment.apiReadRoot + 'Track/GetAlbumTracks', { params: params });
  }

  GetArtistsTopTracks(artistId: string, country: string = 'es'): Observable<Track[]> {

    const params = new HttpParams()
      .set('artistId', artistId)
      .set('country', country);

    return this.httpClient.get<Track[]>(environment.apiReadRoot + 'Track/GetArtistsTopTracks', { params: params });
  }

  GetTrack(trackId: string): Observable<Track> {

    const params = new HttpParams().set('trackId', trackId);

    return this.httpClient.get<Track>(environment.apiReadRoot + 'Track/GetTrack', { params: params });
  }
}
