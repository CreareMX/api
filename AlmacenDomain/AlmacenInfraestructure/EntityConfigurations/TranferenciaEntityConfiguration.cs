using CommonCore.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlmacenInfraestructure.EntityConfigurations
{
    public class TranferenciaEntityConfiguration : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.ToTable("transferencias");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.IdEntradaAlmacen).HasColumnName("id_entrada_almacen").IsRequired();
            builder.Property(p => p.IdSalidaAlmacen).HasColumnName("id_salida_almacen").IsRequired();
            builder.Property(p => p.IdUsuarioTransfiere).HasColumnName("id_usuario_transfiere").IsRequired();
            builder.Property(p => p.FechaTranferencia).HasColumnName("fecha_tranferencia").IsRequired();
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

            builder.HasOne(p => p.EntradaAlmacen)
                .WithMany()
                .HasForeignKey(p => p.IdEntradaAlmacen);

            builder.HasOne(p => p.SalidaAlmacen)
                .WithMany()
                .HasForeignKey(p => p.IdSalidaAlmacen);

            builder.HasOne(p => p.UsuarioTransfiere)
                .WithMany()
                .HasForeignKey(p => p.IdUsuarioTransfiere);
        }
    }
}
