using CommonCore.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VentasInfraestructure.EntityConfigurations
{
    internal class ConceptoVentaEntityConfiguration : IEntityTypeConfiguration<ConceptoVenta>
    {
        public void Configure(EntityTypeBuilder<ConceptoVenta> builder)
        {
            builder.ToTable("conceptos_venta");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.IdVenta).HasColumnName("id_venta").IsRequired();
            builder.Property(p => p.IdProducto).HasColumnName("id_producto").IsRequired();
            builder.Property(p => p.Descripcion).HasColumnName("descripcion").IsRequired(false);
            builder.Property(p => p.CodigoInterno).HasColumnName("codigo_interno").IsRequired(false);
            builder.Property(p => p.UnidadInterna).HasColumnName("unidad_interna").IsRequired(false);
            builder.Property(p => p.UnidadSAT).HasColumnName("unidad_sat").IsRequired(false);
            builder.Property(p => p.ProdServCode).HasColumnName("prod_serv_code").IsRequired(false);
            builder.Property(p => p.ObjImpuesto).HasColumnName("obj_impuesto").IsRequired(false);
            builder.Property(p => p.Cantidad).HasColumnName("cantidad").IsRequired(false);
            builder.Property(p => p.PrecioUnitario).HasColumnName("precio_unitario").IsRequired(false);
            builder.Property(p => p.Descuento).HasColumnName("descuento").IsRequired(false);
            builder.Property(p => p.Total).HasColumnName("total").IsRequired(false);
            builder.Property(p => p.TotalDescuento).HasColumnName("total_descuento").IsRequired(false);
            builder.Property(p => p.InformacionAdicional).HasColumnName("informacion_adicional").IsRequired(false);
            builder.Property(p => p.IdLote).HasColumnName("id_lote").IsRequired(false);
            builder.Property(p => p.Activo).HasColumnName("activo").IsRequired();
            builder.Property(p => p.FechaCreacion).HasColumnName("fecha_creacion").IsRequired();
            builder.Property(p => p.UsuarioCreaId).HasColumnName("id_usuario_creacion").IsRequired();
            builder.Property(p => p.FechaUltimaActualizacion).HasColumnName("fecha_ultima_actualizacion").IsRequired(false);
            builder.Property(p => p.UsuarioActualizaId).HasColumnName("id_usuario_ultima_actualizacion").IsRequired(false);

            builder.HasOne(p => p.Producto).WithMany().HasPrincipalKey(u => u.Id).HasForeignKey(p => p.IdProducto);
            builder.HasMany(p => p.Impuestos).WithOne().HasForeignKey(p => p.IdConceptoVenta).HasPrincipalKey(p => p.Id);

        }
    }
}
