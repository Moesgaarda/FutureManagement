/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FutmanTableComponent } from './futman-table.component';

describe('FutmanTableComponent', () => {
  let component: FutmanTableComponent;
  let fixture: ComponentFixture<FutmanTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FutmanTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FutmanTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
