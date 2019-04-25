import { Component, OnInit, Input } from '@angular/core';
import { ArtistViewModel } from 'src/app/music/view-models/artist-view-model';
import { Artist } from 'src/app/core/music/model/artist';
import { Router } from '@angular/router';

@Component({
  selector: 'app-artist-related-artists',
  templateUrl: './artist-related-artists.component.html'
})
export class ArtistRelatedArtistsComponent implements OnInit {

  @Input()
  relatedArtists: ArtistViewModel[];

  constructor(private router: Router) { }

  ngOnInit() {
  }

  onArtistSelected(artist: Artist): void {
    this.router.navigate(['/artists/artist', artist.id]);
  }
}
