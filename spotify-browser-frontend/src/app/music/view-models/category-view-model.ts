import { Category } from 'src/app/core/music/model/category';

export class CategoryViewModel {

    constructor(public category: Category) {}

    get imageUrl(): string {
        return this.category.icons[0].url;
    }

    get id(): string {
        return this.category.id;
    }

    get name(): string {
        return this.category.name;
    }
}
