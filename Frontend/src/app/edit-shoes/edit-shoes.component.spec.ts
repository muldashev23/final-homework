import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditShoesComponent } from './edit-shoes.component';

describe('EditShoesComponent', () => {
  let component: EditShoesComponent;
  let fixture: ComponentFixture<EditShoesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditShoesComponent]
    });
    fixture = TestBed.createComponent(EditShoesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
