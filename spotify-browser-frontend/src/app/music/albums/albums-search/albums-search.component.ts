import { Component, OnInit } from '@angular/core';
import { SearchService } from 'src/app/core/music/search.service';
import { Album } from 'src/app/core/music/model/album';
import { Paging } from 'src/app/core/paging';
import { Artist } from 'src/app/core/music/model/artist';
import { Router, ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlbumComponent } from '../album/album.component';
import { AlbumViewModel } from '../../view-models/album-view-model';
import { Page } from 'src/app/core/page';

@Component({
  selector: 'app-albums-search',
  templateUrl: './albums-search.component.html',
  styleUrls: ['./albums-search.component.scss']
})
export class AlbumsSearchComponent implements OnInit {
  currentPage: Page;
  searchPattern: string;
  pagedAlbum: Paging<AlbumViewModel>;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private searchService: SearchService,
    private modalService: NgbModal ) { }

  ngOnInit() {
    this.route.queryParams.subscribe( queryParams => {
      this.currentPage = new Page(queryParams['page'] ||  Page.defaultPage, queryParams['limit'] ||  Page.defaultLimit );
      if (queryParams['q']) {
        this.searchPattern = queryParams['q'];
        this.search(this.searchPattern, this.currentPage.limit, this.currentPage.offset);
      }
    });
  }

  searchAlbums() {
    this.router.navigate(['/albums/search'], { queryParams: { q: this.searchPattern , page: this.currentPage.page } });
  }

  onPageChanged($event) {
    this.currentPage.page = <number>$event;
    this.searchAlbums();
  }

  onAlbumSelected(album: Album): void {
    const modalRef = this.modalService.open(AlbumComponent );
    modalRef.componentInstance.albumId = album.id;
  }

  onArtistSelected(artist: Artist): void {
    this.router.navigate(['/artists/artist', artist.id]);
  }

  private search(searchPattern: string, limit: number, offset: number) {
    this.searchService.SearchAlbums(searchPattern, limit, offset).subscribe( pagedAlbum => {
      this.pagedAlbum = new Paging< AlbumViewModel>(pagedAlbum, x => new AlbumViewModel(x));
    });
  }
}
