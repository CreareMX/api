using CommonCore.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VentasInfraestructure.EntityConfigurations
{
    internal class ImpuestosConceptoVentaEntityConfiguration : IEntityTypeConfiguration<ImpuestosConceptoVenta>
    {
        public void Configure(EntityTypeBuilder<ImpuestosConceptoVenta> builder)
        {
            builder.ToTable("impuestos_concepto_venta");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.IdConceptoVenta).HasColumnName("id_concepto_venta").IsRequired();
            builder.Property(p => p.TipoTasaCuota).HasColumnName("tipo_tasa_cuota").IsRequired(false);
            builder.Property(p => p.ImpuestoCode).HasColumnName("impuesto_code").IsRequired(false);
            builder.Property(p => p.TipoFactor).HasColumnName("tipo_factor").IsRequired(false);
            builder.Property(p => p.TipoImpuesto).HasColumnName("tipo_impuesto").IsRequired(false);
            builder.Property(p => p.Base).HasColumnName("base").IsRequired(false);
            builder.Property(p => p.TasaCuota).HasColumnName("tasa_cuota").IsRequired(false);
            builder.Property(p => p.Importe).HasColumnName("importe").IsRequired(false);
            builder.Property(p => p.FechaCreacion).HasColumnName("fecha_creacion").IsRequired();
            builder.Property(p => p.UsuarioCreaId).HasColumnName("id_usuario_creacion").IsRequired();
            builder.Property(p => p.FechaUltimaActualizacion).HasColumnName("fecha_ultima_actualizacion").IsRequired(false);
            builder.Property(p => p.UsuarioActualizaId).HasColumnName("id_usuario_ultima_actualizacion").IsRequired(false);
        }
    }
}
