import { Artist } from './artist';
import { Image } from './image';
import { ExternalUrls } from './external-urls';

export interface Album {
    albumGroup?: any;
    albumType: string;
    artists: Artist[];
    availableMarkets: string[];
    href: string;
    id: string;
    images: Image[];
    name: string;
    releaseDate: string;
    type: string;
    uri: string;
    externalUrls: ExternalUrls;
    tags: string[];
}
