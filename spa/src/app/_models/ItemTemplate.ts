import {ItemPropertyName} from './ItemPropertyName';
import { ItemTemplatePart } from './ItemTemplatePart';
import { ItemTemplatePartOf} from './ItemTemplatePartOf';
import { DetailFile } from './DetailFile';

export enum UnitType {mm = 1, cm, m, stk, paller, par}

export interface ItemTemplate {
    id: number;
    name: string;
    unitType: UnitType;
    revisionId: number;
    revisionedFrom: ItemTemplate;
    created: Date;
    files: any;
    fileNames: string[];
    templateProperties: ItemPropertyName[];
    parts: ItemTemplatePart[];
    partOf: ItemTemplatePartOf[];
    description: string;
    lowerLimit: number;
}
