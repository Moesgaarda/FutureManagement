import { User } from './User';


export interface EventLog {
    id: number;
    user: User;
    description: string;
    date: Date;

}
