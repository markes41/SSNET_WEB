using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using SSNET_DataModel.Models;

namespace SSNET_DataModel.Mapping
{
    public class UsuariosMap : EntityTypeConfiguration<Usuarios>
    {

        public UsuariosMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Username).IsRequired().HasMaxLength(50);
            this.Property(t => t.Password).IsRequired().HasMaxLength(50);
            this.Property(t => t.Email).IsRequired().HasMaxLength(150);
            this.Property(t => t.Nombre).IsRequired().HasMaxLength(50);
            this.Property(t => t.Apellido).IsRequired().HasMaxLength(50);
            this.Property(t => t.CodeVerification).HasMaxLength(8);

            this.ToTable("Usuarios");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Rol).HasColumnName("Rol");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Apellido).HasColumnName("Apellido");
            this.Property(t => t.CodeVerification).HasColumnName("CodeVerification");
            this.Property(t => t.ProfilePicture).HasColumnName("ProfilePicture");
            this.Ignore(t => t.Productos_Carrito);
        }

    }
}
