import { UserRole } from './UserRole';
import { RoleCategory } from './RoleCategory';

export interface User {
    id: number;
    username: string;
    UserRoles: UserRole[];
    name: string;
    surname: string;
    birthdate: Date;
    isActive: boolean;
    email: string;
    phoneNumber: string;
    roleCategories: RoleCategory[];
}
