import { Component, OnInit, Input } from '@angular/core';
import { ArtistViewModel } from 'src/app/music/view-models/artist-view-model';
import { TrackViewModel } from 'src/app/music/view-models/track-view-model';
import { MyArtistService } from 'src/app/core/music/my-artist.service';

@Component({
  selector: 'app-artist-details',
  templateUrl: './artist-details.component.html'
})
export class ArtistDetailsComponent implements OnInit {

  @Input()
  artist: ArtistViewModel;

  @Input()
  artistsTopTracks: TrackViewModel[];

  newTagForArtist: string;
  toggleAddTag = true;

  constructor( private myArtistService: MyArtistService) { }

  ngOnInit() {
  }

  onAddNewTagForArtist() {
    if (this.newTagForArtist && this.newTagForArtist.trim() !== '' &&   !this.artist.tags.includes(this.newTagForArtist)) {
      this.myArtistService.TagArtist(this.artist.id, this.newTagForArtist).subscribe(
        () => {
          this.artist.tags.push(this.newTagForArtist);
          this.newTagForArtist = '';
          this.toggleAddTag = !this.toggleAddTag;
        });
    }
  }

  onRemoveTagForArtist(tagItem: string) {
    if (tagItem && tagItem !== '') {
      this.myArtistService.UntagArtist(this.artist.id, tagItem).subscribe(
        () => this.artist.tags = this.artist.tags.filter( t => t !== tagItem )
      );
    }
  }
}
