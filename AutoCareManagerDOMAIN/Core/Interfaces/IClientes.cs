using AutoCareManagerDOMAIN.Entities;

namespace AutoCareManagerDOMAIN.Interfaces
{
    public interface IClientes
    {
        Task<bool> DeleteCliente(int id);
        Task<IEnumerable<Cliente>> GetCliente();
        Task<Cliente> GetCliente(int id);
        Task<bool> PostCliente(Cliente cliente);
        Task<bool> PutCliente(Cliente cliente);
    }
}