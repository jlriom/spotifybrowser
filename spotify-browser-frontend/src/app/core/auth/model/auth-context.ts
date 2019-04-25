import { UserProfile } from './user-profile';
import { SimpleClaim } from './simple-claim';

export class AuthContext {
  constructor(public readonly userProfile: UserProfile, public readonly claims: SimpleClaim[] ) {}
}
