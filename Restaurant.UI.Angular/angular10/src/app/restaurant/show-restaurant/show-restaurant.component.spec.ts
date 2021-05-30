import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowRestaurantComponent } from './show-restaurant.component';

describe('ShowRestaurantComponent', () => {
  let component: ShowRestaurantComponent;
  let fixture: ComponentFixture<ShowRestaurantComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowRestaurantComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowRestaurantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
