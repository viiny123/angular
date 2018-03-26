import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrudLivroFormComponent } from './crud-livro-form.component';

describe('CrudLivroFormComponent', () => {
  let component: CrudLivroFormComponent;
  let fixture: ComponentFixture<CrudLivroFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrudLivroFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrudLivroFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
