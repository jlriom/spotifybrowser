import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Artist } from './model/artist';

@Injectable({
  providedIn: 'root'
})
export class MyArtistService {

  constructor(private httpClient: HttpClient) { }

  GetMyArtists(): Observable<Artist[]> {
      return this.httpClient.get<Artist[]>(environment.apiReadRoot + 'MyArtist/GetMyArtists');
  }

  TagArtist(artistId: string, tag: string): Observable<any> {
    return this.httpClient.post(environment.apiWriteRoot + 'MyArtist/TagArtist', { artistId: artistId, tag: tag });
  }

  UntagArtist(artistId: string, tag: string): Observable<any> {
    return this.httpClient.post(environment.apiWriteRoot + 'MyArtist/UntagArtist', { artistId: artistId, tag: tag });
  }
}
