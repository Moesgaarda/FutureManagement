import { UserRole } from './UserRole';

export interface RoleName {
    id: number;
    name: string;
    userRoles: UserRole[];
}
