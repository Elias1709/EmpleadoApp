using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuraciones
{
    public class EmpleadoConfiguracion : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Apellido).IsRequired().HasMaxLength(50);
            builder.Property(x => x.NumeroIdentificacion);
            builder.Property(x => x.Telefono);
            builder.Property(x => x.Email);
            builder.Property(x => x.Estado).IsRequired();
            builder.Property(x => x.CargoId).IsRequired();

            builder.HasOne(x => x.Cargo).WithMany()
                   .HasForeignKey(x => x.CargoId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
