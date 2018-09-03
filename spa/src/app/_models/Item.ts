import {ItemTemplate} from './ItemTemplate';
import {User} from './User';
import {Order} from './Order';
import { ItemPropertyDescription } from './ItemPropertyDescription';
import { ItemItemRelation } from './ItemItemRelation';

export interface Item {
    id: number;
    placement: string;
    amount: number;
    template: ItemTemplate;
    order: Order;
    createdBy: User;
    isActive: boolean;
    parts: ItemItemRelation[];
    properties: ItemPropertyDescription[];
}

