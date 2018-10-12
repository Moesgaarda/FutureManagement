import { User } from './User';
import { Item } from './Item';

export interface Order {
    id: number;
    company: string;
    orderDate: Date;
    deliveryDate: Date;
    orderedBy: User;
    invoicePath: string;
    purchaseNumber: number;
    width: number;
    length: number;
    height: number;
    unitType: string;
    products: Item[];
}
