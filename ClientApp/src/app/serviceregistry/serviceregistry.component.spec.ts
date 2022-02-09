import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceregistryComponent } from './serviceregistry.component';

describe('ServiceregistryComponent', () => {
  let component: ServiceregistryComponent;
  let fixture: ComponentFixture<ServiceregistryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ServiceregistryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ServiceregistryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
