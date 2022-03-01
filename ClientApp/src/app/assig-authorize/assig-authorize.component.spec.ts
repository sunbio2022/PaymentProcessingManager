import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssigAuthorizeComponent } from './assig-authorize.component';

describe('AssigAuthorizeComponent', () => {
  let component: AssigAuthorizeComponent;
  let fixture: ComponentFixture<AssigAuthorizeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssigAuthorizeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssigAuthorizeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
