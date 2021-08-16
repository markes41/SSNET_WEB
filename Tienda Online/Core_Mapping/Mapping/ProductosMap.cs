using SSNET_DataModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSNET_DataModel.Mapping
{
    public class ProductosMap : EntityTypeConfiguration<Productos>
    {

        public ProductosMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Titulo).IsRequired().HasMaxLength(50);
            this.Property(t => t.Moneda).HasMaxLength(50);
            this.Property(t => t.Descripcion).HasMaxLength(200);

            this.ToTable("Productos");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Titulo).HasColumnName("Titulo");
            this.Property(t => t.Cantidad).HasColumnName("Cantidad");
            this.Property(t => t.Moneda).HasColumnName("Moneda");
            this.Property(t => t.Precio).HasColumnName("Precio");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.Imagen).HasColumnName("Imagen");
        }
    }
}