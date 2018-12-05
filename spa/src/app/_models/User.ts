import { UserRole } from './UserRole';

export interface User {
    id: number;
    username: string;
    UserRoles: UserRole[];
    name: string;
    surname: string;
    birthdate: Date;
    isActive: boolean;
    email: string;
    phone: string;
}
