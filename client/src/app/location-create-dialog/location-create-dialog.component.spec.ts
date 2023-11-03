import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LocationCreateDialogComponent } from './location-create-dialog.component';

describe('LocationCreateDialogComponent', () => {
  let component: LocationCreateDialogComponent;
  let fixture: ComponentFixture<LocationCreateDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LocationCreateDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LocationCreateDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
