using AutoCareManagerDOMAIN.Entities;

namespace AutoCareManagerDOMAIN.Interfaces
{
    public interface IDConfiguraciones
    {
        Task<bool> DeleteConfiguracion(int id);
        Task<IEnumerable<Configuracion>> GetConfiguracion();
        Task<Configuracion> GetConfiguracion(int id);
        Task<bool> PostConfiguracion(Configuracion configuracion);
        Task<bool> PutConfiguracion(Configuracion configuracion);
    }
}