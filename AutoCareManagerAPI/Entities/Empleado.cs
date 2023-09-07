﻿namespace AutoCareManagerAPI.Entities
{
    public class Empleado
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correoElectronico { get; set; }
        public string cargo { get; set; }
        public string especializacion { get; set; }
        public bool estado { get; set; }
    }
}