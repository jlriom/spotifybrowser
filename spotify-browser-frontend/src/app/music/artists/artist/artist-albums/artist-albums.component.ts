import { Component, OnInit, Input } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlbumTracksComponent } from '../../album-tracks/album-tracks.component';
import { Album } from 'src/app/core/music/model/album';
import { Artist } from 'src/app/core/music/model/artist';
import { Router } from '@angular/router';
import { AlbumViewModel } from 'src/app/music/view-models/album-view-model';
import { Paging } from 'src/app/core/paging';

@Component({
  selector: 'app-artist-albums',
  templateUrl: './artist-albums.component.html'
})
export class ArtistAlbumsComponent implements OnInit {

  @Input()
  pagedAlbums: Paging<AlbumViewModel>;

  constructor(private modalService: NgbModal, private router: Router) { }

  ngOnInit() {
  }

  onAlbumSelected(album: Album): void {
    const modalRef = this.modalService.open(AlbumTracksComponent ,  { size: 'lg' } );
    modalRef.componentInstance.albumId = album.id;
  }

  onArtistSelected(artist: Artist): void {
    this.router.navigate(['/artists/artist', artist.id]);
  }
}
