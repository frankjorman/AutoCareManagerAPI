using AutoCareManagerDOMAIN.Entities;

namespace AutoCareManagerDOMAIN.Core.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<Usuario> SignIn(Usuario usuario);
        Task<bool> SignUp(Usuario usuario);
        Task<bool> IsEmailRegistered(string username);
    }
}