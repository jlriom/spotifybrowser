import { Image } from './image';

export interface Category {
    href: string;
    id: string;
    name: string;
    icons: Image[];
}
