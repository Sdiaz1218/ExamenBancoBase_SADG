export class Pago {
  pagoID: number;
  Concepto: string;
  Cant_Productos: number;
  Cliente: string;
  Empleado: string;
  Total: number;
  EstatusPago: number;
  constructor(
    pagoID?: number,
    Concepto?: string,
    Cant_Productos?: number,
    Cliente?: string,
    Empleado?: string,
    Total?: number,
    EstatusPago?: number
  ) {
    this.pagoID = pagoID!;
    this.Concepto = Concepto!;
    this.Cant_Productos = Cant_Productos!;
    this.Cliente = Cliente!;
    this.Empleado = Empleado!;
    this.Total = Total!;
    this.EstatusPago = EstatusPago!;
  }
}
