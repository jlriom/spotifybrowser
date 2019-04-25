import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { CategoryService } from 'src/app/core/music/category.service';
import { PlaylistService } from 'src/app/core/music/playlist.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PlayListTracksComponent } from '../play-list-tracks/play-list-tracks.component';
import { AlbumComponent } from 'src/app/music/albums/album/album.component';
import { noop, zip } from 'rxjs';
import { CategoryViewModel } from '../../view-models/category-view-model';
import { map } from 'rxjs/operators';
import { PlayListViewModel } from '../../view-models/play-list-view-model';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html'
})
export class CategoryComponent implements OnInit {

  category: CategoryViewModel;
  playLists: PlayListViewModel[];

  constructor(private route: ActivatedRoute,
    private router: Router,
    private categoryService: CategoryService,
    private playListService: PlaylistService,
    private modalService: NgbModal
    ) { }

  ngOnInit() {
    this.route.paramMap.subscribe((params: ParamMap) =>  {
      const categoryId = params.get('id');
      const category$ = this.categoryService.GetCategory(categoryId)
        .pipe(map(category => new CategoryViewModel(category)));
      const playLists$ = this.playListService.GetCategoryPlaylists(categoryId)
        .pipe(map(playLists => playLists.items ? playLists.items.map(p => new PlayListViewModel(p)) : []));

      zip(category$, playLists$)
        .subscribe(playListForCategory => {
          this.category = playListForCategory[0];
          this.playLists = playListForCategory[1];
        });
    });
  }

  backToCategories() {
    this.router.navigate(['browse/categories']);
  }

  onPlayListClicked(playlist: PlayListViewModel): void {

    const modalRef = this.modalService.open(PlayListTracksComponent ,  { size: 'lg' });
    modalRef.componentInstance.playListId = playlist.id;
    modalRef.result
      .then( (result) => {
        if (result.type === 'album') {
          const modalRefAlbum = this.modalService.open(AlbumComponent );
          modalRefAlbum.componentInstance.albumId = result.id;
        } else if (result.type === 'artist') {
          this.router.navigate(['/artists/artist', result.id]);
        }
      })
      .catch(noop);
  }

}
