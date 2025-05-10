import { Component, OnInit } from '@angular/core';
import { PagosService } from '../service/pagos.service';
import { DataSource } from '@angular/cdk/collections';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Component({
  selector: 'app-consulta',
  templateUrl: './consulta.component.html',
  styleUrls: ['./consulta.component.css']
})
export class ConsultaComponent {
  constructor(public pagosService: PagosService,private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { }
  listaPagos: Array<string> = new Array<string>();
  ngOnInit() {
    debugger;
    this.pagosService.ConsultaPagos();
  }
  ngAfterViewInit() {
  }
  onChange(event: any) {
    debugger;
    this.pagosService.ActualizaEstatus(event);
  }
}
