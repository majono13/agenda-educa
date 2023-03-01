import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotFoundResultsComponent } from './not-found-results.component';

describe('NotFoundResultsComponent', () => {
  let component: NotFoundResultsComponent;
  let fixture: ComponentFixture<NotFoundResultsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NotFoundResultsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NotFoundResultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
