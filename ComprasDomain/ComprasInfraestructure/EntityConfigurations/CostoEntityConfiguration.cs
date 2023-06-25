using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CommonCore.Entities.Purchases;

namespace ComprasInfraestructure.EntityConfigurations
{
    public class CostoEntityConfiguration : IEntityTypeConfiguration<Costo>
    {
        public void Configure(EntityTypeBuilder<Costo> builder)
        {
            builder.ToTable("costos");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.Monto).HasColumnName("costo").IsRequired();
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
        }
    }
}
