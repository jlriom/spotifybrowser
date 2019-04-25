import { Track } from 'src/app/core/music/model/track';
import { AlbumViewModel } from './album-view-model';
import { ArtistViewModel } from './artist-view-model';

export class TrackViewModel {

    album: AlbumViewModel;
    artists: ArtistViewModel[];

    constructor(public track: Track) {
        this.album = this.track.album ? new AlbumViewModel(this.track.album) : null;
        this.artists = track.artists ? track.artists.map( artist => new ArtistViewModel(artist)) : [];
    }

    get id(): string {
        return this.track.id;
    }

    get name(): string {
        return this.track.name;
    }

    get trackNumber(): number {
        return this.track.trackNumber;
    }

    get duration(): string {
        const date = new Date(this.track.durationMs);
        const m = date.getMinutes();
        const s = date.getSeconds();
        return `${m}:${s < 10 ? '0' + s : s }`;
    }
}
