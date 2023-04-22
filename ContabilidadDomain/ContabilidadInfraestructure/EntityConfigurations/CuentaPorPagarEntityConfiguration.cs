using ContabilidadCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContabilidadInfraestructure.EntityConfigurations
{
    public class CuentaPorPagarEntityConfiguration : IEntityTypeConfiguration<CuentaPorPagar>
    {
        public void Configure(EntityTypeBuilder<CuentaPorPagar> builder)
        {
            builder.ToTable("cuentas_por_pagar");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.Folio).HasColumnName("folio").IsRequired();
            builder.Property(p => p.IdProveedor).HasColumnName("id_proveedor").IsRequired();
            builder.Property(p => p.FechaVencimiento).HasColumnName("fecha_vencimiento").IsRequired();
            builder.Property(p => p.Monto).HasColumnName("monto").IsRequired();
            builder.Property(p => p.Saldo).HasColumnName("saldo").IsRequired();
            builder.Property(p => p.Comentarios).HasColumnName("comentarios").IsRequired(false);
            builder.Property(p => p.IdEstado).HasColumnName("id_estado").IsRequired();
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

            builder.HasOne(p => p.Proveedor)
                .WithMany()
                .HasForeignKey(p => p.IdProveedor);

            builder.HasOne(p => p.Estado)
                .WithMany()
                .HasForeignKey(p => p.IdEstado);
        }
    }
}
