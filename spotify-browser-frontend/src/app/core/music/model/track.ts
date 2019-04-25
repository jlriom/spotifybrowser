import { Artist } from './artist';
import { Album } from './album';

export interface Track {
    album: Album;
    artists: Artist[];
    availableMarkets: string[];
    discNumber: number;
    durationMs: number;
    href: string;
    id: string;
    name: string;
    previewUrl?: any;
    trackNumber: number;
    type: string;
    uri: string;
}
