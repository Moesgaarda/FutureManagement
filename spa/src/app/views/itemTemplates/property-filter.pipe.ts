import { Pipe, PipeTransform } from '@angular/core';
import { ItemPropertyName } from '../../_models/ItemPropertyName';

@Pipe({name: 'propertyFilter'})
export class PropertyFilterPipe implements PipeTransform {
  transform(properties: ItemPropertyName[], filterText: string): ItemPropertyName[] {
      if (!filterText) {
        return properties;
      }
      return properties.filter(prop => prop.name.includes(filterText));
  }
}
