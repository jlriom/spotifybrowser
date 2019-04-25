export class UsersSearchCriteria {
    public static defaultEmailSearchPattern = '';
    public static defaultUserState = -1;

    constructor(public userState: number, public email: string) {}
}

