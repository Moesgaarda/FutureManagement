import {ItemProperty} from './ItemProperty';
import { ItemTemplatePart } from './ItemTemplatePart';
export enum UnitType {mm = 1, cm, m}

export interface ItemTemplate {
    id: number;
    name: string;
    unitType: UnitType;
    files: string;
    templateProperties: ItemProperty[];
    parts: ItemTemplatePart[];
    description: string;
}
