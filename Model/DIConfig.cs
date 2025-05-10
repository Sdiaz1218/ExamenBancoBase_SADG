using ExamenBancoBase.Model.Interfaces;
using ExamenBancoBase.Model.Services;
using ExamenBancoBase.SqlModels;

namespace ExamenBancoBase.Model
{
    public class DIConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDBContext, DBContext>();
            services.AddScoped<IPagoService, PagoService>();
        } 
    }
}
