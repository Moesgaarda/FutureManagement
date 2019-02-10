import {ItemPropertyName} from './ItemPropertyName';
import { ItemTemplatePart } from './ItemTemplatePart';
import { ItemTemplatePartOf} from './ItemTemplatePartOf';
import { DetailFile } from './DetailFile';
import { ItemTemplateCategory } from './ItemTemplateCategory';
import { UnitType } from './UnitType';

export interface ItemTemplate {
    id: number;
    name: string;
    unitType: UnitType;
    revisionedFrom: ItemTemplate;
    created: Date;
    files: any;
    fileNames: string[];
    templateProperties: ItemPropertyName[];
    parts: ItemTemplatePart[];
    partOf: ItemTemplatePartOf[];
    description: string;
    lowerLimit: number;
    category: ItemTemplateCategory;
}
