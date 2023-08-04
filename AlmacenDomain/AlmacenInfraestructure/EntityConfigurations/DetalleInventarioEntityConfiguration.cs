using CommonCore.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlmacenInfraestructure.EntityConfigurations
{
    public class DetalleInventarioEntityConfiguration : IEntityTypeConfiguration<DetalleInventario>
    {
        public void Configure(EntityTypeBuilder<DetalleInventario> builder)
        {
            builder.ToTable("inventario_detalle");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.IdInventario).HasColumnName("id_inventario").IsRequired();
            builder.Property(p => p.IdProducto).HasColumnName("id_producto").IsRequired();
            builder.Property(p => p.IdUnidad).HasColumnName("id_unidad").IsRequired();
            builder.Property(p => p.Cantidad).HasColumnName("cantidad").IsRequired();
            builder.Property(p => p.Fecha).HasColumnName("fecha").IsRequired();
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

            builder.HasOne(p => p.Producto)
                .WithMany()
                .HasForeignKey(p => p.IdProducto);

            builder.HasOne(p => p.Unidad)
                .WithMany()
                .HasForeignKey(p => p.IdUnidad);
        }
    }
}
