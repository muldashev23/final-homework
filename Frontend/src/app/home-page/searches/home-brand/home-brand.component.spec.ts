import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeBrandComponent } from './home-brand.component';

describe('HomeBrandComponent', () => {
  let component: HomeBrandComponent;
  let fixture: ComponentFixture<HomeBrandComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HomeBrandComponent]
    });
    fixture = TestBed.createComponent(HomeBrandComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
