
export interface IPagosService {
    apiRoot: string;
    mostrarLoad: boolean;
    mostrarLoadTabla: boolean;
    mostrarForm: boolean;
    mostrarTabla: boolean;
    snackBar: any;
    dataSource: any;
    estatusSeleccionado: any;
    displayedColumns: string[];
    RealizaPago(): void;
    ConsultaPagos(): any;
}