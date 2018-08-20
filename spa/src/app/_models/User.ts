import { UserRole } from './UserRole';

export interface User {
    id: number;
    username: string;
    role: UserRole;
    name: string;
    surName: string;
    birthdate: Date;
    isActive: boolean;
    eMail: string;
    phone: string;
}
