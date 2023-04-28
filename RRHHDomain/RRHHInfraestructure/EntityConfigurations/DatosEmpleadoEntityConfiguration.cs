using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RRHHCore.Entities;

namespace RRHHInfraestructure.EntityConfigurations
{
    public class DatosEmpleadoEntityConfiguration : IEntityTypeConfiguration<DatosEmpleado>
    {
        public void Configure(EntityTypeBuilder<DatosEmpleado> builder)
        {
            builder.ToTable("DatosEmpleadoss");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.IdEmpleado).HasColumnName("id_persona").IsRequired();
            builder.Property(p => p.IdPuesto).HasColumnName("id_puesto").IsRequired();
            builder.Property(p => p.IdDepartamento).HasColumnName("id_departamento").IsRequired();
            builder.Property(p => p.Salario).HasColumnName("salario").IsRequired();
            builder.Property(p => p.FechaContratacion).HasColumnName("nombre").IsRequired();
            builder.Property(p => p.Activo).HasColumnName("activo").IsRequired();
            builder.Property(p => p.FechaCreacion).HasColumnName("fecha_creacion").IsRequired();
            builder.Property(p => p.UsuarioCreaId).HasColumnName("id_usuario_creacion").IsRequired();
            builder.Property(p => p.FechaUltimaActualizacion).HasColumnName("fecha_ultima_actualizacion").IsRequired(false);
            builder.Property(p => p.UsuarioActualizaId).HasColumnName("id_usuario_ultima_actualizacion").IsRequired(false);

            builder.HasOne(p => p.UsuarioCrea)
                .WithMany()
                .HasForeignKey(p => p.UsuarioCreaId);

            builder.HasOne(p => p.UsuarioActualiza)
                .WithMany()
                .HasForeignKey(p => p.UsuarioActualizaId);
        }
    }
}
