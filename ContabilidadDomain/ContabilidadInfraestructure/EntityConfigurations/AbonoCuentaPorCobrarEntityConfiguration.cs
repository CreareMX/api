using ContabilidadCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContabilidadInfraestructure.EntityConfigurations
{
    public class AbonoCuentaPorCobrarEntityConfiguration : IEntityTypeConfiguration<AbonoCuentaPorCobrar>
    {
        public void Configure(EntityTypeBuilder<AbonoCuentaPorCobrar> builder)
        {
            builder.ToTable("abonos_cuentas_por_cobrar");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.IdCuentaPorCobrar).HasColumnName("id_cuenta_por_cobrar").IsRequired();
            builder.Property(p => p.Fecha).HasColumnName("fecha").IsRequired();
            builder.Property(p => p.Monto).HasColumnName("monto").IsRequired();
            builder.Property(p => p.Comentarios).HasColumnName("comentarios").IsRequired(false);
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

            builder.HasOne(p => p.CuentaPorCobrar)
                .WithMany(p => p.AbonosCuentaPorCobrar)
                .HasForeignKey(p => p.IdCuentaPorCobrar);
        }
    }
}
