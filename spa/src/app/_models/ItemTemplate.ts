import {ItemPropertyName} from './ItemPropertyName';
import { ItemTemplatePart } from './ItemTemplatePart';

export enum UnitType {mm = 1, cm, m, stk, paller, par}

export interface ItemTemplate {
    id: number;
    name: string;
    unitType: UnitType;
    revisionId: number;
    created: Date;
    files: any;
    fileNames: string[];
    templateProperties: ItemPropertyName[];
    parts: ItemTemplatePart[];
    description: string;
}
