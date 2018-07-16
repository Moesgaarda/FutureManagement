import { Injectable } from '@angular/core';

@Injectable()
export class ItemTableService {

  data = [{
    name: 'Skrue',
    placement: 'Hal 3 plads 8',
    amount: '29 stk',
    properties: 'Malingsfarve og behandling',
    type: 'Ingen skabelon',
  }, {
    name: 'Skrue 2',
    placement: 'Hal 3 plads 9',
    amount: '25 stk',
    properties: 'Ingen',
    type: 'Ingen skabelon',
  }, {
    name: 'Spær',
    placement: 'Hal 4 plads 32',
    amount: '2 paller',
    properties: 'Malingsfarve',
    type: 'Spær skabelon',
  }, {
    name: 'Mindre spær',
    placement: 'Hal 4 plads 30',
    amount: '8 paller',
    properties: 'Behandling',
    type: 'Mindre spør skabelon',
  }, {
    name: 'Skrue',
    placement: 'Hal 3 plads 8',
    amount: '29 stk',
    properties: 'Malingsfarve og behandling',
    type: 'Ingen skabelon',
  }, {
    name: 'Skrue 2',
    placement: 'Hal 3 plads 9',
    amount: '25 stk',
    properties: 'Ingen',
    type: 'Ingen skabelon',
  }, {
    name: 'Spær',
    placement: 'Hal 4 plads 32',
    amount: '2 paller',
    properties: 'Malingsfarve',
    type: 'Spær skabelon',
  }, {
    name: 'Mindre spær',
    placement: 'Hal 4 plads 30',
    amount: '8 paller',
    properties: 'Behandling',
    type: 'Mindre spær skabelon',
  }, {
    name: 'Skrue',
    placement: 'Hal 3 plads 8',
    amount: '29 stk',
    properties: 'Malingsfarve og behandling',
    type: 'Ingen skabelon',
  }, {
    name: 'Skrue 2',
    placement: 'Hal 3 plads 9',
    amount: '25 stk',
    properties: 'Ingen',
    type: 'Ingen skabelon',
  }, {
    name: 'Spær',
    placement: 'Hal 4 plads 32',
    amount: '2 paller',
    properties: 'Malingsfarve',
    type: 'Spær skabelon',
  }, {
    name: 'Mindre spær',
    placement: 'Hal 4 plads 30',
    amount: '8 paller',
    properties: 'Behandling',
    type: 'Mindre spør skabelon',
  }, {
    name: 'Skrue',
    placement: 'Hal 3 plads 8',
    amount: '29 stk',
    properties: 'Malingsfarve og behandling',
    type: 'Ingen skabelon',
  }, {
    name: 'Skrue 2',
    placement: 'Hal 3 plads 9',
    amount: '25 stk',
    properties: 'Ingen',
    type: 'Ingen skabelon',
  }, {
    name: 'Spær',
    placement: 'Hal 4 plads 32',
    amount: '2 paller',
    properties: 'Malingsfarve',
    type: 'Spær skabelon',
  }, {
    name: 'Mindre spær',
    placement: 'Hal 4 plads 30',
    amount: '8 paller',
    properties: 'Behandling',
    type: 'Mindre spær skabelon',
  }];

  getData() {
    return this.data;
  }
}
