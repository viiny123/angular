import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { Route, extract } from '@app/core';
import { CrudLivroFormComponent } from '@app/pages/crud-livro/crud-livro-form/crud-livro-form.component';

const routes: Routes = [
  // Module is lazy loaded, see app-routing.module.ts
  Route.withShell([
    { path: 'cadastro-livro', component: CrudLivroFormComponent, data: { title: extract('Livro') } },
    { path: 'cadastro-livro/:id', component: CrudLivroFormComponent, data: { title: extract('Livro') } }
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class PagesRoutingModule { }
