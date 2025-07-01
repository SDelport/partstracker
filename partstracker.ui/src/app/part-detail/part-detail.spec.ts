import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PartDetail } from './part-detail';

describe('PartDetail', () => {
  let component: PartDetail;
  let fixture: ComponentFixture<PartDetail>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PartDetail]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PartDetail);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
