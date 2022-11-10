using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPesaje.BL
{
    internal class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("Server=DESKTOP-T76L6AS\\SQLEXPRESS;Database=CRUDPesaje;Trusted_Connection=True;")
        {
        
        }
        public virtual DbSet<Empresa> Empresa { get; set; } 
    }
}
