using CommonCore.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlmacenInfraestructure.EntityConfigurations
{
    public class AlmacenEntityConfiguration : IEntityTypeConfiguration<Almacen>
    {
        public void Configure(EntityTypeBuilder<Almacen> builder)
        {
            builder.ToTable("almacenes");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.Nombre).HasColumnName("nombre").IsRequired();
            builder.Property(p => p.Descripcion).HasColumnName("descripcion").IsRequired();
            builder.Property(p => p.Codigo).HasColumnName("codigo").IsRequired();
            builder.Property(p => p.IdTipoAlmacen).HasColumnName("id_tipo_almacen").IsRequired();
            builder.Property(p => p.IdSucursal).HasColumnName("id_sucursal").IsRequired();
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

            builder.HasOne(p => p.TipoAlmacen)
                .WithMany()
                .HasForeignKey(p => p.IdTipoAlmacen);

            builder.HasOne(p => p.Sucursal)
                .WithMany()
                .HasForeignKey(p => p.IdSucursal);
        }
    }
}
