import { User } from './User';
import { Item } from './Item';
import { OrderStatus } from './OrderStatus';

export interface Order {
    id: number;
    company: string;
    orderDate: Date;
    deliveryDate: Date;
    orderedBy: User;
    purchaseNumber: number;
    width: number;
    length: number;
    height: number;
    unitType: string;
    products: Item[];
    files: any;
    fileNames: string[];
    status: OrderStatus;
}
