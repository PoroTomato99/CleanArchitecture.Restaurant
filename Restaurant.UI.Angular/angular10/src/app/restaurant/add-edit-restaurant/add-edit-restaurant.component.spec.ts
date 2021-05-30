import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditRestaurantComponent } from './add-edit-restaurant.component';

describe('AddEditRestaurantComponent', () => {
  let component: AddEditRestaurantComponent;
  let fixture: ComponentFixture<AddEditRestaurantComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditRestaurantComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditRestaurantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
