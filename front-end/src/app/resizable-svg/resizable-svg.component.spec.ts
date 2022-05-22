import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResizableSvgComponent } from './resizable-svg.component';

describe('ResizableSvgComponent', () => {
  let component: ResizableSvgComponent;
  let fixture: ComponentFixture<ResizableSvgComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResizableSvgComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResizableSvgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
