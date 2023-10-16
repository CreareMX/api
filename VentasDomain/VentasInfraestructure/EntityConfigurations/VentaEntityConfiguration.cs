using CommonCore.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VentasInfraestructure.EntityConfigurations
{
    public class VentaEntityConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("ventas");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.IdCliente).HasColumnName("id_cliente").IsRequired();
            builder.Property(p => p.IdSucursal).HasColumnName("id_sucursal").IsRequired();
            builder.Property(p => p.Vendedor).HasColumnName("vendedor").IsRequired();
            builder.Property(p => p.Moneda).HasColumnName("moneda").IsRequired();
            builder.Property(p => p.TipoCambio).HasColumnName("tipo_cambio").IsRequired(false);
            builder.Property(p => p.FormaPago).HasColumnName("forma_pago").IsRequired();
            builder.Property(p => p.Metodopago).HasColumnName("metodo_pago").IsRequired();
            builder.Property(p => p.Serie).HasColumnName("serie").IsRequired();
            builder.Property(p => p.Folio).HasColumnName("folio").IsRequired();
            builder.Property(p => p.Subtotal).HasColumnName("subtotal").IsRequired();
            builder.Property(p => p.Descuento).HasColumnName("descuento").IsRequired(false);
            builder.Property(p => p.Total).HasColumnName("total").IsRequired();
            builder.Property(p => p.Fecha).HasColumnName("fecha").IsRequired();
            builder.Property(p => p.Estatus).HasColumnName("estatus").IsRequired();
            builder.Property(p => p.IdEstatus).HasColumnName("id_estatus").IsRequired(false);
            builder.Property(p => p.FechaCreacion).HasColumnName("fecha_creacion").IsRequired();
            builder.Property(p => p.UsuarioCreaId).HasColumnName("id_usuario_creacion").IsRequired();
            builder.Property(p => p.FechaUltimaActualizacion).HasColumnName("fecha_ultima_actualizacion").IsRequired(false);
            builder.Property(p => p.UsuarioActualizaId).HasColumnName("id_usuario_ultima_actualizacion").IsRequired(false);

            builder.HasOne(p => p.Persona).WithMany().HasPrincipalKey(u => u.Id).HasForeignKey(p => p.IdCliente);
            builder.HasOne(p => p.Sucursal).WithMany().HasPrincipalKey(u => u.Id).HasForeignKey(p => p.IdSucursal);
            builder.HasMany(p => p.ConceptosVenta).WithOne().HasForeignKey(p => p.IdVenta).HasPrincipalKey(p => p.Id);
        }
    }
}
