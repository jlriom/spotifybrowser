import { PlayList } from 'src/app/core/music/model/playlist';
import { TrackViewModel } from './track-view-model';

export class PlayListViewModel {

    tracks: TrackViewModel[];

    constructor(public playList: PlayList) {
        this.tracks = playList.tracks.items ? playList.tracks.items.map( track => new TrackViewModel(track.track)) : [];
    }

    get id(): string {
        return this.playList.id;
    }

    get name(): string {
        return this.playList.name;
    }

    get description(): string {
        return this.playList.description;
    }

    get imageUrl(): string {
        return this.playList.images[0].url;
    }

    get spotifyUrl(): string {
        return this.playList.externalUrls.spotify;
    }

    get numTracks(): number {
        return  this.playList.tracks.total;
    }
}
