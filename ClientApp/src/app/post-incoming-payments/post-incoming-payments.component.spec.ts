import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostIncomingPaymentsComponent } from './post-incoming-payments.component';

describe('PostIncomingPaymentsComponent', () => {
  let component: PostIncomingPaymentsComponent;
  let fixture: ComponentFixture<PostIncomingPaymentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostIncomingPaymentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostIncomingPaymentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
