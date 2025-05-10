using ExamenBancoBase.Model.Interfaces;
using ExamenBancoBase.SqlModels;
using Newtonsoft.Json;

namespace ExamenBancoBase.Model.Services
{
    public class PagoService : IPagoService
    {
        private IDBContext _context;
        public PagoService(IDBContext context)
        {
            _context = context;
        }

        public bool ActualizarPago(string id, string valorN)
        {
            try
            {
                _context.ExecSql($"EXEC dbo.ActualizaRegistro {id},{valorN}");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string ObtenerPagos()
        {
            List<Pago> pagos = JsonConvert.DeserializeObject<List<Pago>>(JsonConvert.SerializeObject(_context.GetDataSet($"SELECT * from dbo.ObtenerAllPagos();").Tables[0]));

            return JsonConvert.SerializeObject(pagos);
        }
        public bool RegistrarPago(string infoPago)
        {
            try
            {
                _context.ExecSql($"EXEC dbo.RegistrarPago '{infoPago}'");
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
