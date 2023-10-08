using AutoCareManagerAPI.Entities;
using AutoCareManagerAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoCareManagerAPI.Data
{
    public class DConfiguraciones : IDConfiguraciones
    {
        private readonly AutoCareManagerContext _context;

        public DConfiguraciones(AutoCareManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Configuracion>> GetConfiguracion()
        {

            return await _context.Configuracion.ToListAsync();
        }

        public async Task<Configuracion> GetConfiguracion(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var configuracion = await _context.Configuracion.FindAsync(id);

            if (configuracion == null)
            {
                return null;
            }

            return configuracion;
        }

        public async Task<bool> PutConfiguracion(Configuracion configuracion)
        {
            if (configuracion == null)
            {
                return false;
            }

            _context.Configuracion.Update(configuracion);


            var resultado = await _context.SaveChangesAsync();


            return resultado == 1 ? true : false;
        }


        public async Task<bool> PostConfiguracion(Configuracion configuracion)
        {
            if (configuracion == null)
            {
                return false;
            }

            _context.Configuracion.Add(configuracion);


            var resultado = await _context.SaveChangesAsync();
            return resultado == 1 ? true : false;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteConfiguracion(int id)
        {
            if (id == 0)
            {
                return false;
            }
            var configuracion = await _context.Configuracion.FindAsync(id);
            if (configuracion == null)
            {
                return false;
            }

            _context.Configuracion.Remove(configuracion);
            var resultado = await _context.SaveChangesAsync();

            return resultado == 1 ? true : false;
        }

        private bool ConfiguracionExists(string id)
        {
            return (_context.Configuracion?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
