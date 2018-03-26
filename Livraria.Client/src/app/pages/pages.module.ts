import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CrudLivroComponent } from './crud-livro/crud-livro.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { LivroService } from '@app/core/services/livro.service';
import { MaterialModule } from '@app/material.module';
import { RouterModule } from '@angular/router';
import { NgxPaginationModule } from 'ngx-pagination';
import { PagesRoutingModule } from '@app/pages/pages-routing.module';
import { HttpBaseService } from '@app/core/service-helper/HttpBaseService';
import { CrudLivroFormComponent } from './crud-livro/crud-livro-form/crud-livro-form.component';
import { TranslateModule } from '@ngx-translate/core';
import { SharedModule } from '@app/shared';
import { CoreModule } from '@app/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    TranslateModule,
    MaterialModule,
    RouterModule,
    NgxPaginationModule,
    PagesRoutingModule,
    SharedModule,
    CoreModule,
    BrowserModule,
    BrowserAnimationsModule
  ],
  providers: [LivroService, HttpBaseService],
  declarations: [CrudLivroComponent, CrudLivroFormComponent],
  exports: [CrudLivroComponent]
})
export class PagesModule { }
