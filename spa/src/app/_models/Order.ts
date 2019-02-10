import { User } from './User';
import { Item } from './Item';
import { OrderStatusEnum } from '../_enums/OrderStatusEnum.enum';
import { UnitType } from './UnitType';

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
    unitType: UnitType;
    products: Item[];
    files: any;
    fileNames: string[];
    status: OrderStatusEnum;
}
