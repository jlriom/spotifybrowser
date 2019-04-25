import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Album } from 'src/app/core/music/model/album';
import { AlbumService } from 'src/app/core/music/album.service';
import { TrackService } from 'src/app/core/music/track.service';
import { Paging } from 'src/app/core/paging';
import { Track } from 'src/app/core/music/model/track';
import { Router } from '@angular/router';
import { Artist } from 'src/app/core/music/model/artist';
import { AlbumViewModel } from 'src/app/music/view-models/album-view-model';
import { TrackViewModel } from 'src/app/music/view-models/track-view-model';
import { zip } from 'rxjs';

@Component({
  selector: 'app-album-details',
  templateUrl: './album-details.component.html'
})
export class AlbumDetailsComponent implements OnInit {

  @Input() albumId: string;
  @Output() artistSelected: EventEmitter<string> = new EventEmitter<string>();

  album: AlbumViewModel;
  tracks: Paging<TrackViewModel>;

  constructor(private router: Router, private albumService: AlbumService, private trackService: TrackService) { }

  ngOnInit() {

    const album$ = this.albumService.GetAlbum(this.albumId);
    const albumTracks$ = this.trackService.GetAlbumTracks(this.albumId);

    zip(album$, albumTracks$)
      .subscribe( albumTracks => {
        this.album = new AlbumViewModel(albumTracks[0]);
        this.tracks =  new Paging<TrackViewModel>(albumTracks[1], track => new TrackViewModel(track));
      });
  }

  onArtistSelected(artist: Artist): void {
    this.artistSelected.emit(artist.id);
    this.router.navigate(['/artists/artist', artist.id]);
  }

}
