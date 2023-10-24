using AutoCareManagerDOMAIN.Entities;
using AutoCareManagerDOMAIN.Infraestructure.Data;
using AutoCareManagerDOMAIN.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoCareManagerDOMAIN.Infraestructure.Repositories
{
    public class ClientesRepository : IClientes
    {
        private readonly AutoCareManagerContext _context;
        private readonly IClientes _cliente;

        public ClientesRepository(AutoCareManagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetCliente()
        {
            return await _context.Cliente.ToListAsync();
        }


        public async Task<Cliente> GetCliente(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return null;
            }

            return cliente;
        }

        public async Task<bool> PutCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                return false;
            }

            _context.Cliente.Update(cliente);
            try
            {
                var resultado = await _context.SaveChangesAsync();
                return resultado == 1 ? true : false;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }


        }

        public async Task<bool> PostCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                return false;
            }
            _context.Cliente.Add(cliente);
            var resultado = await _context.SaveChangesAsync();

            return resultado == 1 ? true : false;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCliente(int id)
        {
            if (id == 0)
            {
                return false;
            }
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return false;
            }

            _context.Cliente.Remove(cliente);
            var resultado = await _context.SaveChangesAsync();
            return resultado == 1 ? true : false;
        }

        private bool ClienteExists(int id)
        {
            return (_context.Cliente?.Any(e => e.IdCliente == id)).GetValueOrDefault();
        }


    }
}
