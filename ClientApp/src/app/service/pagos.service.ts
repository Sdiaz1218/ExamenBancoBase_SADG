import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { inject, Inject, Injectable } from '@angular/core';
import { Pago } from '../pagos/model/Pago';
import { environment } from 'src/environments/environment';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IPagosService } from './pagos.interface';
@Injectable({
  providedIn: 'root',
})
export class PagosService implements IPagosService {
  public pagoInfo: Pago = new Pago();
  apiRoot: string;
  mostrarLoad: boolean = false;
  mostrarLoadTabla: boolean = true;
  mostrarForm: boolean = true;
  mostrarTabla: boolean = false;
  snackBar = inject(MatSnackBar);
  dataSource: any;
  estatusSeleccionado: any;
  displayedColumns: string[] = [
    'Concepto',
    'Cant_Productos',
    'Cliente',
    'Empleado',
    'Monto',
    'Estatus',
  ];
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiRoot = environment.urlBack;
  }
  ngOnInit(): void {}

  public RealizaPago(): void {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
    };
    let pagoJson = JSON.stringify(JSON.stringify(this.pagoInfo));
    this.mostrarLoad = true;
    this.mostrarForm = false;
    this.http
      .post(`${this.apiRoot}pagos/guardapago`, pagoJson, httpOptions)
      .subscribe(
        (result) => {
          console.log(result);
          this.mostrarLoad = false;
          this.mostrarForm = true;
          if (!result) {
            this.snackBar.open(
              'Error al ingresar la información del pago, favor de verificar.',
              'Ok'
            );
          } else {
            this.snackBar.open('Guardado Correcto de Pago.', 'Ok');
          }
        },
        (error) => this.snackBar.open('Error guardar pago.', 'Ok')
      );
  }
  public ConsultaPagos(): any {
    debugger;
    this.http.get(`${this.apiRoot}pagos/obtenerpagos`).subscribe(
      (result) => {
        this.dataSource = result;
        this.mostrarLoadTabla = false;
        this.mostrarTabla = true;
      },
      (error) => this.snackBar.open('Error al consultar pagos.', 'Ok')
    );
  }
  public ActualizaEstatus(event: any): any {
    debugger;
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
    };
    this.http
      .put(
        `${this.apiRoot}pagos/actualizapago`,
        `"${event.source.value.toString()}"`,
        httpOptions
      )
      .subscribe(
        (result) => {
          if (!result) {
            this.snackBar.open('Error al actualizar el estus del pago.', 'Ok');
          } else {
            this.snackBar.open('Actualización de Pago.', 'Ok');
          }
          this.mostrarLoadTabla = false;
          this.mostrarTabla = true;
        },
        (error) =>
          this.snackBar.open('Error  al actualizar el estatus del pago.', 'Ok')
      );
  }
}
