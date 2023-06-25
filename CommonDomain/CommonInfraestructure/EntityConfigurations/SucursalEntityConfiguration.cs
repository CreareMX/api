using CommonCore.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommonInfraestructure.EntityConfigurations
{
    public class SucursalEntityConfiguration : IEntityTypeConfiguration<Sucursal>
    {
        public void Configure(EntityTypeBuilder<Sucursal> builder)
        {
            builder.ToTable("sucursales");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.Nombre).HasColumnName("nombre").IsRequired();
            builder.Property(p => p.Domicilio).HasColumnName("domicilio").IsRequired();
            builder.Property(p => p.Telefono).HasColumnName("telefono").IsRequired(false);
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
