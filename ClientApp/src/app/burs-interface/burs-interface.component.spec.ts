import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BursInterfaceComponent } from './burs-interface.component';

describe('BursInterfaceComponent', () => {
  let component: BursInterfaceComponent;
  let fixture: ComponentFixture<BursInterfaceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BursInterfaceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BursInterfaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
