using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlmacenInfraestructure.EntityConfigurations
{
    public class GastoGeneralFijoEntityConfiguration : IEntityTypeConfiguration<GastoGeneralFijo>
    {
        public void Configure(EntityTypeBuilder<GastoGeneralFijo> builder)
        {
            builder.ToTable("gastos_generales_fijos");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.Descripcion).HasColumnName("descripcion").IsRequired();
            builder.Property(p => p.Monto).HasColumnName("monto").IsRequired();
            builder.Property(p => p.IdConcepto).HasColumnName("id_concepto").IsRequired();
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

            builder.HasOne(p => p.Concepto)
                .WithMany()
                .HasForeignKey(p => p.IdConcepto);
        }
    }
}
