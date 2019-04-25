import { Image } from './image';
import { ExternalUrls } from './external-urls';

export interface Artist {
    href: string;
    id: string;
    name: string;
    type: string;
    images: Image[];
    uri: string;
    externalUrls: ExternalUrls;
    tags: string[];
}
