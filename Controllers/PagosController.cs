using ExamenBancoBase.Model;
using ExamenBancoBase.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace ExamenBancoBase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IPagoService _pagoService;

        public PagosController(IPagoService pagoService)
        {
            _pagoService = pagoService;
        }

        [HttpPost]
        [Route("guardapago")]
        public bool GuardaPago([FromBody] string infoPago)
        {
            try
            {
                Pago pagoInf = JsonConvert.DeserializeObject<Pago>(infoPago);
                string paramPago = $"''{pagoInf.Concepto}'',{pagoInf.Cant_Productos},''{pagoInf.Cliente}'',''{pagoInf.Empleado}'',{pagoInf.Total},{Convert.ToInt16(pagoInf.Estatus)}";
                return _pagoService.RegistrarPago(paramPago);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [HttpGet]
        [Route("obtenerpagos")]
        public String ObtenPagos()
        {
            return _pagoService.ObtenerPagos();
        }
        [HttpPut]
        [Route("actualizapago")]
        public bool ActualizaPago([FromBody]string valorN)
        {
            string[] valores = valorN.Split(",");
            return _pagoService.ActualizarPago(valores[1].ToString(), valores[0]);
        }
    }
}