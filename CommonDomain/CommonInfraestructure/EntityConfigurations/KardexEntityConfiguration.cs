using CommonCore.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommonInfraestructure.EntityConfigurations
{
    public class KardexEntityConfiguration : IEntityTypeConfiguration<Kardex>
    {
        public void Configure(EntityTypeBuilder<Kardex> builder)
        {
            builder.ToTable("kardex_vw");
            builder.HasKey(x => x.Id);
            
            builder.Property(p => p.IdProducto).HasColumnName("id_producto").IsRequired();
            builder.Property(p => p.Producto).HasColumnName("producto").IsRequired();
            builder.Property(p => p.CodigoProducto).HasColumnName("codigo_producto").IsRequired(false);
            builder.Property(p => p.CodigoBarras).HasColumnName("codigo_barras").IsRequired(false);
            builder.Property(p => p.IdUnidad).HasColumnName("id_unidad").IsRequired();
            builder.Property(p => p.Unidad).HasColumnName("unidad").IsRequired();
            builder.Property(p => p.Entrada).HasColumnName("entrada").IsRequired(false);
            builder.Property(p => p.FechaEntrada).HasColumnName("fecha_entrada").IsRequired(false);
            builder.Property(p => p.Salida).HasColumnName("salida").IsRequired(false);
            builder.Property(p => p.FechaSalida).HasColumnName("fecha_salida").IsRequired(false);
            builder.Property(p => p.IdAlmacen).HasColumnName("id_almacen").IsRequired();
            builder.Property(p => p.Almacen).HasColumnName("almacen").IsRequired();
            builder.Property(p => p.IdEstado).HasColumnName("id_estado").IsRequired();
            builder.Property(p => p.Estado).HasColumnName("estado").IsRequired();
            builder.Property(p => p.IdConcepto).HasColumnName("id_concepto").IsRequired();
            builder.Property(p => p.Concepto).HasColumnName("concepto").IsRequired();

            builder.Ignore(x => x.Activo);
            builder.Ignore(x => x.FechaCreacion);
            builder.Ignore(x => x.FechaUltimaActualizacion);
            builder.Ignore(x => x.UsuarioCreaId);
            builder.Ignore(x => x.UsuarioCrea);
            builder.Ignore(x => x.UsuarioActualizaId);
            builder.Ignore(x => x.UsuarioActualiza);
        }
    }
}
