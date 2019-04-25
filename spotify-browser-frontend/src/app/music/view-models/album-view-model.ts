import { Album } from 'src/app/core/music/model/album';
import { ArtistViewModel } from './artist-view-model';

export class AlbumViewModel {

    artists: ArtistViewModel[];

    constructor(public album: Album) {
        this.artists = album.artists ? album.artists.map( artist => new ArtistViewModel(artist)) : [];
    }

    get id(): string {
        return this.album.id;
    }

    get name(): string {
        return this.album.name;
    }

    get imageUrl(): string {
        return this.album.images && this.album.images.length > 0  ?  this.album.images[0].url : 'https://picsum.photos/200/200/?blur';
    }

    get spotifyUrl(): string {
        return this.album.externalUrls.spotify;
    }

    get ReleaseYear(): string {
        try {
            const releaseDate = new Date(this.album.releaseDate);
            return releaseDate.getFullYear().toString();
          } catch {
            const year = parseInt(this.album.releaseDate, 0);
            return year.toString();
          }
    }
}
