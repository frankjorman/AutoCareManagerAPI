using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCareManagerDOMAIN.Core.Entities
{
    public class Repuesto
    {
        public int IdRepuesto { get; set; }
        public string? Descripcion { get; set; }
        public decimal Costo { get; set; }
    }
}
