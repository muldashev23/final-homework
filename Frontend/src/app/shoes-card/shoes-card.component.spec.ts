import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoesCardComponent } from './shoes-card.component';

describe('ShoesCardComponent', () => {
  let component: ShoesCardComponent;
  let fixture: ComponentFixture<ShoesCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShoesCardComponent]
    });
    fixture = TestBed.createComponent(ShoesCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
