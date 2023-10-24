using AutoCareManagerDOMAIN.Entities;

namespace AutoCareManagerDOMAIN.Core.Interfaces
{
    public interface IEmpleadosRepository
    {
        Task<bool> DeleteEmpleado(int id);
        Task<IEnumerable<Empleado>> GetEmpleado();
        Task<Empleado> GetEmpleadoId(int id);
        Task<bool> PostEmpleado(Empleado empleado);
        Task<bool> PutEmpleado(Empleado empleado);
    }
}