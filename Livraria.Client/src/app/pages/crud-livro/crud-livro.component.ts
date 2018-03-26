import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { LivroService } from '@app/core/services/livro.service';
import { MatDialog, MatSnackBar, MatDialogRef } from '@angular/material';
import { Router, ActivatedRoute } from '@angular/router';
import { DialogComponent } from '@app/core/dialog/dialog.component';

@Component({
  selector: 'app-crud-livro',
  templateUrl: './crud-livro.component.html',
  styleUrls: ['./crud-livro.component.scss']
})
export class CrudLivroComponent implements OnInit {
  private livroSubj = new BehaviorSubject<Array<any>>([]);
  private livros: Observable<Array<any>> = this.livroSubj.asObservable();

  pesquisar: any;
  tableHover = true;
  tableStriped = true;
  tableCondensed = true;
  tableBordered = true;

  page = 1;
  total = 1;

  private dialogRef: MatDialogRef<DialogComponent>;

  constructor(
    private service: LivroService,
    public dialog: MatDialog,
    private router: Router,
    private route: ActivatedRoute,
    public snackBar: MatSnackBar) { }

  ngOnInit() {
    this.getLivros(1);
  }

  pageChange(value: any) {
    this.page = value;
  }

  getLivros(value: any) {
    // this.showLoading(true);
    this.service.get()
      .subscribe(ok => {
        // this.showLoading(false);
        this.livroSubj.next(ok.data);
        this.total = ok.data.length;
        this.page = value;
      },
      err => {
        // this.showLoading(false);
      });
  }

  openSnackBar(message: string) {
    this.snackBar.open(message, 'Fechar', { duration: 15000 });
  }

  refresh() {
    this.ngOnInit();
  }

  search(val: any) {
    this.livros = this.livroSubj.map(models => models.filter(r =>
      r.tituloLivro.toLowerCase().indexOf(val) >= 0
      || r.autor.toLowerCase().indexOf(val) >= 0
      || r.nomeEditora.toLowerCase().indexOf(val) >= 0
      || r.isbn.toLowerCase().indexOf(val) >= 0
    ));

    return this.livros
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

  delete(item: any) {
    this.dialogRef = this.dialog.open(DialogComponent, {
      disableClose: false,
      width: '250px'
    });

    this.dialogRef.componentInstance.confirmMessage = 'Deseja remover o livro ?';

    this.dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.service.delete(item.id)
          .subscribe(ok => {
            this.openSnackBar(ok.data.message);
            this.refresh();
          },
          err => {
            this.renderError(err);
          }
        }
    });

  }

}
