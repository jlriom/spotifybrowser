import { RegisterUserInfo } from 'src/app/core/account/model/RegisterUserInfo';

export class RegisterInfo implements RegisterUserInfo {

    constructor(
        public email: string = 'user@jl.org ',
        public firstName: string = 'userFirstName',
        public lastName: string = 'userLastName ',
        public password: string = '!QAZ2wsx',
        public confirmPassword: string = '!QAZ2wsx') { }
}
