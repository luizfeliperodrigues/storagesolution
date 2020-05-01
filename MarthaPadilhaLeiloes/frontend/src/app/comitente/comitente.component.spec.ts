/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ComitenteComponent } from './comitente.component';

describe('ComitenteComponent', () => {
  let component: ComitenteComponent;
  let fixture: ComponentFixture<ComitenteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComitenteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComitenteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
