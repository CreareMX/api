using CommonCore.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComprasInfraestructure.EntityConfigurations
{
    public class ProductoEntityConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("productos");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.Nombre).HasColumnName("nombre").IsRequired();
            builder.Property(p => p.Descripcion).HasColumnName("descripcion").IsRequired(false);
            builder.Property(p => p.CodigoBarras).HasColumnName("codigo_barras").IsRequired();
            builder.Property(p => p.NumeroSerie).HasColumnName("numero_serie").IsRequired();
            builder.Property(p => p.IdCategoria).HasColumnName("id_categoria").IsRequired();
            builder.Property(p => p.Codigo).HasColumnName("codigo_producto").IsRequired(false);
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

            builder.HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.IdCategoria);

            builder.HasMany(p => p.Precios)
                .WithOne(p => p.Producto)
                .HasForeignKey(p => p.IdProducto)
                .HasPrincipalKey(p => p.Id);
        }
    }
}
