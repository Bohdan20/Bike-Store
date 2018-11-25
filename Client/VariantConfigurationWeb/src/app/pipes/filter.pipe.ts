import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ConfigurationsModel } from '../models/configurations.model';
import { filter } from 'rxjs/operator/filter';

@Pipe({name: 'filter'})
export class FilterPipe implements PipeTransform {
  constructor() {}

  transform(items: ConfigurationsModel[], query: string) {
    return query ? items.filter(item => item.Customer.toLowerCase().indexOf(query) !== -1) : items;
  }
}
