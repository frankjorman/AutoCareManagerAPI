﻿using AutoCareManagerAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoCareManagerAPI.Data
{
    public class DEmpleados
    {
        private readonly AutoCareManagerContext _context;

        public DEmpleados(AutoCareManagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> GetEmpleado()
        {
            return await _context.Empleado.ToListAsync();
        }

        public async Task<Empleado> GetEmpleado(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var empleado = await _context.Empleado.FindAsync(id);

            if (empleado == null)
            {
                return null;
            }

            return empleado;
        }

        public async Task<bool> PutEmpleado(Empleado empleado)
        {
            if (empleado == null)
            {
                return false;
            }

            _context.Empleado.Update(empleado);

            
            var resultado = await _context.SaveChangesAsync();


            return resultado == 1 ? true:false ;
        }

        public async Task<bool> PostEmpleado(Empleado empleado)
        {
            if (empleado == null)
            {
                return false;
            }
            _context.Empleado.Add(empleado);
            var resultado = await _context.SaveChangesAsync();

            return resultado==1?true:false;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteEmpleado(int id)
        {
            if (id == 0)
            {
                return false;
            }
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return false;
            }

            _context.Empleado.Remove(empleado);
            var resultado = await _context.SaveChangesAsync();

            return resultado == 1?true:false;
        }

        private bool EmpleadoExists(int id)
        {
            return (_context.Empleado?.Any(e => e.IdEmpleado == id)).GetValueOrDefault();
        }
    }
}
