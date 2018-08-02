import {ItemTemplate} from './ItemTemplate';
import {User} from './User';
import {Order} from './Order';
import { ItemPropertyName } from './ItemPropertyName';

export interface Item {
    id: number;
    placement: string;
    amount: number;
    template: ItemTemplate;
    order: Order;
    createdBy: User;
    isArchived: boolean;
    parts: Item[];
    // properties: ItemPropertyDescription[];
}

