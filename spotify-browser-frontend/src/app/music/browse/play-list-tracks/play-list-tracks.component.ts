import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { PlaylistService } from 'src/app/core/music/playlist.service';
import { PlayListViewModel } from '../../view-models/play-list-view-model';
import { AlbumViewModel } from '../../view-models/album-view-model';
import { ArtistViewModel } from '../../view-models/artist-view-model';

@Component({
  selector: 'app-play-list-tracks',
  templateUrl: './play-list-tracks.component.html'
})
export class PlayListTracksComponent implements OnInit {

  @Input() playListId: string;

  playList: PlayListViewModel;

  constructor(private playListService: PlaylistService, public activeModal: NgbActiveModal) {}

  ngOnInit() {
    this.playListService.GetPlaylist(this.playListId).subscribe(playList => this.playList = new PlayListViewModel(playList));
  }

  dismiss() {
    this.activeModal.dismiss();
  }

  onAlbumSelected(album: AlbumViewModel) {
    this.activeModal.close({ type: 'album', id: album.id });
  }

  onArtistSelected(artist: ArtistViewModel) {
    this.activeModal.close({ type: 'artist', id: artist.id });
  }
}
