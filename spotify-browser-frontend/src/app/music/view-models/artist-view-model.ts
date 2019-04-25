import { Artist } from 'src/app/core/music/model/artist';

export class ArtistViewModel {

    constructor(public artist: Artist) {}

    get id(): string {
        return this.artist.id;
    }

    get name(): string {
        return this.artist.name;
    }

    get imageUrl(): string {
        return  this.artist.images && this.artist.images.length > 0 ? this.artist.images[0].url : 'https://picsum.photos/200/200/?blur';
    }

    get spotifyUrl(): string {
        return this.artist.externalUrls.spotify;
    }

    get tags(): string[] {
        return this.artist.tags;
    }

    set tags(value: string[]) {
        this.artist.tags = value;
    }
}
