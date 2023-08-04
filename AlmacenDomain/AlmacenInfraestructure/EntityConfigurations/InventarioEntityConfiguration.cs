using CommonCore.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlmacenInfraestructure.EntityConfigurations
{
    public class InventarioEntityConfiguration : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.ToTable("inventario");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.IdAlmacen).HasColumnName("id_almacen").IsRequired();
            builder.Property(p => p.IdUsuarioInicio).HasColumnName("id_usuario_inicio").IsRequired();
            builder.Property(p => p.FechaInicio).HasColumnName("fecha_inicio").IsRequired();
            builder.Property(p => p.IdUsuarioFin).HasColumnName("id_usuario_fin").IsRequired(false);
            builder.Property(p => p.FechaFin).HasColumnName("fecha_fin").IsRequired(false);
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

            builder.HasOne(p => p.Almacen)
                .WithMany()
                .HasForeignKey(p => p.IdAlmacen);

            builder.HasOne(p => p.UsuarioInicio)
                .WithMany()
                .HasForeignKey(p => p.IdUsuarioInicio);

            builder.HasOne(p => p.UsuarioFin)
                .WithMany()
                .HasForeignKey(p => p.IdUsuarioFin);

            builder.HasOne(p => p.Almacen)
                .WithMany()
                .HasForeignKey(p => p.IdAlmacen);

            builder.HasMany(p => p.Detalles)
                .WithOne(p => p.Inventario)
                .HasForeignKey(p => p.IdInventario)
                .HasPrincipalKey(p => p.Id);
        }
    }
}
