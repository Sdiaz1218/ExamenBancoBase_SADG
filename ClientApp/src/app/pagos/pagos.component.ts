import { Component, OnInit, Inject } from '@angular/core';
import { PagosService } from '../service/pagos.service';

@Component({
  selector: 'app-pagos',
  templateUrl: './pagos.component.html',
  styleUrls: ['./pagos.component.css']
})
export class PagosComponent implements OnInit {
  constructor(
    public  pagosService: PagosService) {
   }

  ngOnInit(): void {
  }
 
}
