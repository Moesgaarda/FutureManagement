import { ItemTemplate } from './ItemTemplate';

export interface ItemTemplatePart {
    templateId: number;
    template: ItemTemplate;
    partId: number;
    part: ItemTemplate;
    amount: number;
}
