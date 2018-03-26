import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})
export class DialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<DialogComponent>) {}

  public titulo = 'Atenção';
  public confirmMessage: string;
  public showCancelar: Boolean = true;
  public showConfirmar: Boolean = true;
  public Confirmar = 'Confirmar';
  public Cancelar = 'Cancelar';

  ngOnInit() {
  }

}
