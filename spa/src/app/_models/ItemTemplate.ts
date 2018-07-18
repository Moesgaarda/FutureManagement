import {ItemPropertyCategory} from './ItemPropertyCategory';
enum UnitType {mm, cm, m}

export interface ItemTemplate {
    id: number;
    name: string;
    unitType: UnitType;
    files: string;
    propertyList: ItemPropertyCategory[];
    templateList: ItemTemplate[];
    description: string;
}
