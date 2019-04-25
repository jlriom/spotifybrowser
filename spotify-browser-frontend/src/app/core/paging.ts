export interface IPaging<T> {
    href: string;
    items: T[];
    limit: number;
    offset: number;
    next: string;
    previous?: any;
    total: number;
}


export class Paging<T> implements IPaging<T> {
    href: string;
    items: T[];
    limit: number;
    offset: number;
    next: string;
    previous?: any;

    private _total: number;

    get total(): number {
        if (this._total > 1000) {
          return 1000;
        }
        return this._total;
      }

    constructor( pagedList: IPaging<any>, itemMapper: (any: any) => T ) {
        this.href = pagedList.href;
        this.limit = pagedList.limit;
        this.offset = pagedList.offset;
        this.next = pagedList.next;
        this.previous = pagedList.previous;
        this._total = pagedList.total;
        this.items = pagedList.items.map( i => itemMapper(i));
    }
}
