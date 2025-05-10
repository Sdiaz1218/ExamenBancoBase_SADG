using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ExamenBancoBase.Model
{
    public class Pago
    {
        public int PagoID { get; set; }
        public string Concepto { get; set; }
        public int Cant_Productos { get; set; }
        public string Cliente { get; set; }
        public string Empleado { get; set; }
        public decimal Total { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public EstatusPagoEnum Estatus { get; set; }
    }
}
