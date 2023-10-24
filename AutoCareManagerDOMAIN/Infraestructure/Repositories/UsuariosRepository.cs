using AutoCareManagerDOMAIN.Core.Interfaces;
using AutoCareManagerDOMAIN.Entities;
using AutoCareManagerDOMAIN.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoCareManagerDOMAIN.Infraestructure.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly AutoCareManagerContext _context;

        public UsuariosRepository(AutoCareManagerContext context)
        {
            _context = context;
        }

        public async Task<Usuario> SignIn(Usuario usuario)
        {
            var resultado = await _context
                .Usuario
                .Where(x => x.Username == usuario.Username && x.Password == usuario.Password)
                .FirstOrDefaultAsync();
            if (resultado == null)
            {
                return null;
            }
            return resultado;
        }

        public async Task<bool> SignUp(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> IsEmailRegistered(string username)
        {
            return await _context
                .Usuario
                .Where(x => x.Username == username).AnyAsync();
        }
    }
}
