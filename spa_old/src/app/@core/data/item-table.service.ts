import { Injectable } from '@angular/core';

@Injectable()
export class ItemTableService {

  data = [{
      name: 'Skrue',
      placement: 'Hal 3 plads 8',
      amount: '29 stk',
      order: 'Ordre #4',
      type: 'Ingen skabelon',
    }, {
      name: 'Skrue 2',
      placement: 'Hal 3 plads 9',
      amount: '25 stk',
      order: 'Ordre #7',
      type: 'Ingen skabelon',
    }, {
      name: 'Spær',
      placement: 'Hal 4 plads 32',
      amount: '2 paller',
      order: 'Ordre #30',
      type: 'Spær skabelon',
    }, {
      name: 'Mindre spær',
      placement: 'Hal 4 plads 30',
      amount: '8 paller',
      order: 'Ordre #32',
      type: 'Mindre spær skabelon',
    }, {
      name: 'Skrue',
      placement: 'Hal 3 plads 8',
      amount: '29 stk',
      order: 'Ordre #4',
      type: 'Ingen skabelon',
    }, {
      name: 'Skrue 2',
      placement: 'Hal 3 plads 9',
      amount: '25 stk',
      order: 'Ordre #7',
      type: 'Ingen skabelon',
    }, {
      name: 'Spær',
      placement: 'Hal 4 plads 32',
      amount: '2 paller',
      order: 'Ordre #30',
      type: 'Spær skabelon',
    }, {
      name: 'Mindre spær',
      placement: 'Hal 4 plads 30',
      amount: '8 paller',
      order: 'Ordre #32',
      type: 'Mindre spær skabelon',
    }, {
      name: 'Skrue',
      placement: 'Hal 3 plads 8',
      amount: '29 stk',
      order: 'Ordre #4',
      type: 'Ingen skabelon',
    }, {
      name: 'Skrue 2',
      placement: 'Hal 3 plads 9',
      amount: '25 stk',
      order: 'Ordre #7',
      type: 'Ingen skabelon',
    }, {
      name: 'Spær',
      placement: 'Hal 4 plads 32',
      amount: '2 paller',
      order: 'Ordre #30',
      type: 'Spær skabelon',
    }, {
      name: 'Mindre spær',
      placement: 'Hal 4 plads 30',
      amount: '8 paller',
      order: 'Ordre #32',
      type: 'Mindre spær skabelon',
    }, {
      name: 'Skrue',
      placement: 'Hal 3 plads 8',
      amount: '29 stk',
      order: 'Ordre #4',
      type: 'Ingen skabelon',
    }, {
      name: 'Skrue 2',
      placement: 'Hal 3 plads 9',
      amount: '25 stk',
      order: 'Ordre #7',
      type: 'Ingen skabelon',
    }, {
      name: 'Spær',
      placement: 'Hal 4 plads 32',
      amount: '2 paller',
      order: 'Ordre #30',
      type: 'Spær skabelon',
    }, {
      name: 'Mindre spær',
      placement: 'Hal 4 plads 30',
      amount: '8 paller',
      order: 'Ordre #32',
      type: 'Mindre spær skabelon',
    }, {
    name: 'Skrue',
    placement: 'Hal 3 plads 8',
    amount: '29 stk',
    order: 'Ordre #4',
    type: 'Ingen skabelon',
  }, {
    name: 'Skrue 2',
    placement: 'Hal 3 plads 9',
    amount: '25 stk',
    order: 'Ordre #7',
    type: 'Ingen skabelon',
  }, {
    name: 'Spær',
    placement: 'Hal 4 plads 32',
    amount: '2 paller',
    order: 'Ordre #30',
    type: 'Spær skabelon',
  }, {
    name: 'Mindre spær',
    placement: 'Hal 4 plads 30',
    amount: '8 paller',
    order: 'Ordre #32',
    type: 'Mindre spær skabelon',
  }];

  getData() {
    return this.data;
  }
}
