export class Page {
    public static defaultLimit = 10;
    public static defaultPage = 1;
    limit = Page.defaultLimit;
    page = Page.defaultPage;

    constructor(page: number, limit: number) {
        this.page = page;
        this.limit = limit;
    }

    get offset(): number {
        return (this.page - 1) * this.limit;
    }
}
