import {ItemPropertyCategory} from './ItemPropertyCategory';
enum UnitType {mm, cm, m}

export interface ItemTemplate {
    id: number;
    name: string;
    unitType: UnitType;
    description: string;
    files: string;
    propertyList: ItemPropertyCategory[];
    templateList: ItemTemplate[];
}
