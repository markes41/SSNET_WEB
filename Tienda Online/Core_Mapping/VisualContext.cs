using SSNET_DataModel.Mapping;
using SSNET_DataModel.Models;
using SSNET_DataModel.Models.Comercio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSNET_DataModel
{
    public class VisualContext : DbContext
    {
        public VisualContext()
            : base("Server=DESKTOP-VCVN96I;Database=SSNET_WEB;User=sa;Password=sqlcoop;MultipleActiveResultSets=true;Persist Security Info=True;")
        {
        }

        public DbSet<Productos> Productos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Compras> Compras { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductosMap());
            modelBuilder.Configurations.Add(new UsuariosMap());
            modelBuilder.Configurations.Add(new ComprasMap());
        }
    }
}
