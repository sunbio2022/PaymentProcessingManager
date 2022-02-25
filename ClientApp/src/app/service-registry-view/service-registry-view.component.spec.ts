import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceRegistryViewComponent } from './service-registry-view.component';

describe('ServiceRegistryViewComponent', () => {
  let component: ServiceRegistryViewComponent;
  let fixture: ComponentFixture<ServiceRegistryViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ServiceRegistryViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ServiceRegistryViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
