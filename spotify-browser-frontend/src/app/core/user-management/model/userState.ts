export enum UserState {
    PendingToActivate = 0,
    Active = 1,
    Deactive = 2,
    Unregistered = 4
}

const stateDescrition: {[ id: number]: string } = {};

stateDescrition[<number> UserState.PendingToActivate] = 'Pending';
stateDescrition[<number> UserState.Active] = 'Active';
stateDescrition[<number> UserState.Deactive] = 'Deactivated';
stateDescrition[<number> UserState.Unregistered] = 'Unregistered';

export function getUserStateDescription( userState: number): string {
    return stateDescrition[userState];
}

export function getUserStateDescriptions(): {[ id: number]: string } {
    return stateDescrition;
}
