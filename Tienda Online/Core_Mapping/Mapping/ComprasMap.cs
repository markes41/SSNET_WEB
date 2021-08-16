using SSNET_DataModel.Models.Comercio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace SSNET_DataModel.Mapping
{
    public class ComprasMap : EntityTypeConfiguration<Compras>
    {

        public ComprasMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Productos_Id).HasMaxLength(500);

            this.ToTable("Compras");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Productos_Id).HasColumnName("Productos_Id");
            this.Property(t => t.Procesado).HasColumnName("Procesado");
            this.Property(t => t.Comprador_Id).HasColumnName("Comprador_Id");
            this.Property(t => t.Fecha_Compra).HasColumnName("Fecha_Compra");
            this.Property(t => t.Precio).HasColumnName("Precio");
            this.HasRequired(t => t.Comprador).WithMany().HasForeignKey(d => d.Comprador_Id);

        }
    }
}

