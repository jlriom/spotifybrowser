import { Component, OnInit } from '@angular/core';
import { Artist } from 'src/app/core/music/model/artist';
import { ArtistService } from 'src/app/core/music/artist.service';
import { ActivatedRoute } from '@angular/router';
import { Album } from 'src/app/core/music/model/album';
import { AlbumService } from 'src/app/core/music/album.service';
import { TrackService } from 'src/app/core/music/track.service';
import { Paging } from 'src/app/core/paging';
import { Track } from 'src/app/core/music/model/track';
import { ArtistViewModel } from '../../view-models/artist-view-model';
import { AlbumViewModel } from '../../view-models/album-view-model';
import { TrackViewModel } from '../../view-models/track-view-model';
import { Page } from 'src/app/core/page';
import { zip } from 'rxjs';

@Component({
  selector: 'app-artist',
  templateUrl: './artist.component.html'
})
export class ArtistComponent implements OnInit {

  artistId: string;

  currentPage: Page = new Page(1, 20);

  artist: ArtistViewModel;
  relatedArtists: ArtistViewModel[];
  pagedAlbums: Paging<AlbumViewModel>;
  artistsTopTracks: TrackViewModel[];

  newTagForArtist: string;
  toggleAddTag = true;

  constructor(
    private activatedRoute: ActivatedRoute,
    private artistService: ArtistService,
    private albumService: AlbumService,
    private trackService: TrackService) { }


  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.artistId = params['id'];

      const artist$ =  this.artistService.GetArtist(this.artistId);
      const relatedArtists$ = this.artistService.GetRelatedArtists(this.artistId);
      const topTracks$ = this.trackService.GetArtistsTopTracks(this.artistId);
      const artistAlbums$ = this.albumService.GetArtistsAlbums(this.artistId, this.currentPage.limit, this.currentPage.offset);

      zip(artist$, relatedArtists$, topTracks$, artistAlbums$).subscribe(artistDetails => {
          this.artist =  new ArtistViewModel(artistDetails[0]);
          this.relatedArtists = artistDetails[1].map( relatedArtist => new ArtistViewModel(relatedArtist));
          this.artistsTopTracks = artistDetails[2].map( track => new TrackViewModel(track));
          this.pagedAlbums = new Paging<AlbumViewModel>(artistDetails[3], album => new AlbumViewModel(album));
        });
    });
  }
}
