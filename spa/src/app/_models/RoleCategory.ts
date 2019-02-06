import { UserRole } from './UserRole';

export interface RoleCategory {
    id: number;
    name: string;
    userRoles: UserRole[];
}
