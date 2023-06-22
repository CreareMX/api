using ComprasCore.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComprasInfraestructure.EntityConfigurations
{
    public class ProveedorProductoEntityConfiguration : IEntityTypeConfiguration<ProveedorProducto>
    {
        public void Configure(EntityTypeBuilder<ProveedorProducto> builder)
        {
            builder.ToTable("proveedores_productos");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.IdProducto).HasColumnName("id_producto").IsRequired();
            builder.Property(p => p.IdProveedor).HasColumnName("id_proveedor").IsRequired();
            builder.Property(p => p.IdCosto).HasColumnName("id_costo").IsRequired();
            builder.Property(p => p.Activo).HasColumnName("activo").IsRequired();
            builder.Property(p => p.FechaCreacion).HasColumnName("fecha_creacion").IsRequired();
            builder.Property(p => p.UsuarioCreaId).HasColumnName("id_usuario_creacion").IsRequired();
            builder.Property(p => p.FechaUltimaActualizacion).HasColumnName("fecha_ultima_actualizacion").IsRequired(false);
            builder.Property(p => p.UsuarioActualizaId).HasColumnName("id_usuario_ultima_actualizacion").IsRequired(false);

            builder.HasOne(p => p.Producto)
                .WithMany()
                .HasForeignKey(p => p.IdProducto);

            builder.HasOne(p => p.Proveedor)
                .WithMany()
                .HasForeignKey(p => p.IdProveedor);

            builder.HasOne(p => p.Costo)
                .WithMany()
                .HasForeignKey(p => p.IdCosto);

            builder.HasOne(p => p.UsuarioCrea)
                .WithMany()
                .HasForeignKey(p => p.UsuarioCreaId);

            builder.HasOne(p => p.UsuarioActualiza)
                .WithMany()
                .HasForeignKey(p => p.UsuarioActualizaId);
        }
    }
}
