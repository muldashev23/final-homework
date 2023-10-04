import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeGenderComponent } from './home-gender.component';

describe('HomeGenderComponent', () => {
  let component: HomeGenderComponent;
  let fixture: ComponentFixture<HomeGenderComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HomeGenderComponent]
    });
    fixture = TestBed.createComponent(HomeGenderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
