import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-album',
  templateUrl: './album-tracks.component.html'
})
export class AlbumTracksComponent implements OnInit {

  @Input()
  albumId: string;

  constructor(private activeModal: NgbActiveModal) { }

  ngOnInit() {
  }

  dismiss() {
    this.activeModal.dismiss();
  }

  onArtistSelected($event: string) {
    this.activeModal.dismiss();
  }
}
