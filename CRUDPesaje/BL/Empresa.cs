using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPesaje.BL
{
    internal class Empresa
    {
        public int EmpresaID { get; set; }
        public string Nombre { get; set; }
        public int Codigo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Cuidad { get; set; }
        public string Departamento { get; set; }
        public string Pais { get; set; }
        public DateTime? FechaAdd { get; set; }
        public DateTime? FechaEdit { get; set; }


    }
}
