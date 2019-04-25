import { Component, OnInit } from '@angular/core';
import { SearchService } from 'src/app/core/music/search.service';
import { Artist } from 'src/app/core/music/model/artist';
import { Paging } from 'src/app/core/paging';
import { Router, ActivatedRoute } from '@angular/router';
import { ArtistViewModel } from '../../view-models/artist-view-model';
import { Page } from 'src/app/core/page';

@Component({
  selector: 'app-artists-search',
  templateUrl: './artists-search.component.html',
  styleUrls: ['./artists-search.component.scss']
})
export class ArtistsSearchComponent implements OnInit {
  searchPattern: string;
  currentPage: Page;
  pagedArtist: Paging<ArtistViewModel>;

  constructor(private router: Router, private route: ActivatedRoute, private  searchService: SearchService) { }

  ngOnInit() {
    this.route.queryParams.subscribe( queryParams => {
      this.currentPage = new Page( queryParams['page'] || Page.defaultPage, queryParams['limit'] ||  Page.defaultLimit);
      if (queryParams['q']) {
        this.searchPattern = queryParams['q'];
        this.search(this.searchPattern, this.currentPage.limit, this.currentPage.offset);
      }
    });
  }

  searchArtists() {
    this.router.navigate(['/artists/search'], { queryParams: { q: this.searchPattern , page: this.currentPage.page } });
  }

  onPageChanged($event) {
    this.currentPage.page = <number>$event;
    this.searchArtists();
  }

  private search(searchPattern: string, limit: number, offset: number) {
    this.searchService.SearchArtists(searchPattern, limit, offset)
      .subscribe( pagedArtist => this.pagedArtist = new Paging<ArtistViewModel>(pagedArtist, artist => new  ArtistViewModel(artist)));
  }

  onArtistSelected(artist: Artist): void {
    this.router.navigate(['/artists/artist', artist.id]);
  }
}
