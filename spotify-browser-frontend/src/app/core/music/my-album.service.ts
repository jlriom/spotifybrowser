import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Album } from './model/album';

@Injectable({
  providedIn: 'root'
})
export class MyAlbumService {

  constructor(private httpClient: HttpClient) { }

  GetMyAlbums(): Observable<Album[]> {
      return this.httpClient.get<any>(environment.apiReadRoot + 'MyAlbum/GetMyAlbums');
  }

  TagAlbum(albumId: string, tag: string ): Observable<any> {
    return this.httpClient.post(environment.apiWriteRoot + 'MyAlbum/TagAlbum', {albumId: albumId, tag: tag});
  }

  UntagAlbum(albumId: string, tag: string): Observable<any> {
    return this.httpClient.post(environment.apiWriteRoot + 'MyAlbum/UntagAlbum', {albumId: albumId, tag: tag});
  }
}
