import { Paging } from '../../paging';
import { Track } from './track';
import { Image } from './image';
import { ExternalUrls } from './external-urls';


export interface Owner {
    displayName: string;
    externalUrls: ExternalUrls;
    href: string;
    id: string;
    images: any[];
    type: string;
    uri: string;
}

export interface PlayListTrack {
    addedAt: Date;
    addedBy: Owner;
    track: Track;
    isLocal: boolean;
}

export interface PlayList {
    collaborative: boolean;
    description: string;
    externalUrls: ExternalUrls;
    href: string;
    id: string;
    images: Image[];
    name: string;
    owner: Owner;
    public?: boolean;
    snapshotId: string;
    tracks: Paging<PlayListTrack>;
    type: string;
    uri: string;
}
