import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FindEmployeePairsByProjectsComponent } from './find-employee-pairs-by-projects.component';

describe('FindEmployeePairsByProjectsComponent', () => {
  let component: FindEmployeePairsByProjectsComponent;
  let fixture: ComponentFixture<FindEmployeePairsByProjectsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FindEmployeePairsByProjectsComponent]
    });
    fixture = TestBed.createComponent(FindEmployeePairsByProjectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
