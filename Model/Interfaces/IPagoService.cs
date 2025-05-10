namespace ExamenBancoBase.Model.Interfaces
{
    public interface IPagoService
    {
        bool RegistrarPago(string infoPago);
        bool ActualizarPago(string id, string valorN);
        string ObtenerPagos();
    }
}
