import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { LivroService } from '@app/core/services/livro.service';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-crud-livro-form',
  templateUrl: './crud-livro-form.component.html',
  styleUrls: ['./crud-livro-form.component.scss']
})
export class CrudLivroFormComponent implements OnInit {

  form: FormGroup;
  title: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private service: LivroService,
    public snackBar: MatSnackBar) {
    this.createForm();
  }

  ngOnInit() {
    const sub = this.route.params.subscribe(params => {
      const id = params['id'];

      this.title = id ? 'Editar Livro' : 'Cadastrar Livro';

      if (!id) {
        this.form.reset();
        return;
      }

      this.service.getById(id)
        .subscribe(response => {
          this.form.controls['id'].setValue(response.data.id);
          this.form.controls['TituloLivro'].setValue(response.data.tituloLivro);
          this.form.controls['Nome'].setValue(response.data.nome);
          this.form.controls['Sobrenome'].setValue(response.data.sobrenome);
          this.form.controls['NomeEditora'].setValue(response.data.nomeEditora);
          this.form.controls['Cnpj'].setValue(response.data.cnpj);
          this.form.controls['Rua'].setValue(response.data.rua);
          this.form.controls['Numero'].setValue(response.data.numero);
          this.form.controls['Bairro'].setValue(response.data.bairro);
          this.form.controls['Cidade'].setValue(response.data.cidade);
          this.form.controls['Estado'].setValue(response.data.estado);
          this.form.controls['Cep'].setValue(response.data.cep);
          this.form.controls['Formato'].setValue(response.data.formato);
          this.form.controls['Peso'].setValue(response.data.peso);
          this.form.controls['Paginas'].setValue(response.data.paginas);
          this.form.controls['ISBN'].setValue(response.data.isbn);
          this.form.controls['Ano'].setValue(response.data.ano);
          this.form.controls['Estoque'].setValue(response.data.estoque);
        });
    });
  }

  createForm() {
    this.form = this.formBuilder.group({
      id: [''],
      TituloLivro: ['', [Validators.required]],
      Nome: ['', [Validators.required]],
      Sobrenome: ['', [Validators.required]],
      NomeEditora: ['', [Validators.required]],
      Cnpj: ['', [Validators.required]],
      Rua: ['', [Validators.required]],
      Numero: ['', [Validators.required]],
      Bairro: ['', [Validators.required]],
      Cidade: ['', [Validators.required]],
      Estado: ['', [Validators.required]],
      Cep: ['', [Validators.required]],
      Formato: ['', [Validators.required]],
      Peso: ['', [Validators.required]],
      Paginas: ['', [Validators.required]],
      ISBN: ['', [Validators.required]],
      Ano: ['', [Validators.required]],
      Estoque: ['', [Validators.required]],
    });
  }

  save() {
    const value = this.form.value;

    if (value.id) {
      this.service.update(value)
        .subscribe(response => {
          this.openSnackBar(response.data.message);
        },
        err => {
          this.renderError(err);
        });
    } else {
      this.service.add(value)
        .subscribe(response => {
          this.openSnackBar(response.data.message);
        },
        err => {
          this.renderError(err);
        });
    }
  }

  openSnackBar(message: string) {
    this.snackBar.open(message, 'Fechar', { duration: 10000 });
  }

  renderError(err: any) {
    if (err.json().errors) {
      let msg = '';

      for (const item of err.json().errors) {
        msg = msg + item.message + '\n';
      }

      this.openSnackBar(msg);
    }
  }
}
