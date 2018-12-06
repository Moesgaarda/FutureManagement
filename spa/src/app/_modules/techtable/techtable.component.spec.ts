/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TechtableComponent } from './techtable.component';

describe('TechtableComponent', () => {
  let component: TechtableComponent;
  let fixture: ComponentFixture<TechtableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TechtableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TechtableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
