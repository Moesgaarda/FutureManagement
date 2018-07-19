import {ItemProperty} from './ItemProperty';
enum UnitType {mm, cm, m}

export interface ItemTemplate {
    id: number;
    name: string;
    unitType: UnitType;
    files: string;
    propertyList: ItemProperty[];
    templateList: ItemTemplate[];
    description: string;
}
