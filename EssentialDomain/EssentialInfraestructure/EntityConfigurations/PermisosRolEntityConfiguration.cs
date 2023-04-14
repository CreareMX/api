using EssentialCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EssentialInfraestructure.EntityConfigurations
{
    public class PermisosRolEntityConfiguration : IEntityTypeConfiguration<PermisosRol>
    {
        public void Configure(EntityTypeBuilder<PermisosRol> builder)
        {
            builder.ToTable("permisos_rol");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.RolId).HasColumnName("nombre").IsRequired();
            builder.Property(p => p.Activo).HasColumnName("activo").IsRequired();
            builder.Property(p => p.FehaCreacion).HasColumnName("fecha_creacion").IsRequired();
            builder.Property(p => p.UsuarioCreaId).HasColumnName("id_usuario_creacion").IsRequired();
            builder.Property(p => p.FechaUltimaActualizacion).HasColumnName("fecha_ultima_actualizacion").IsRequired(false);
            builder.Property(p => p.UsuarioActualizaId).HasColumnName("id_usuario_ultima_actualizacion").IsRequired(false);

            builder.HasOne(p => p.UsuarioCrea)
                .WithMany()
                .HasForeignKey(p => p.UsuarioCreaId);

            builder.HasOne(p => p.UsuarioActualiza)
                .WithMany()
                .HasForeignKey(p => p.UsuarioActualizaId);

            builder.HasOne(p => p.Rol)
                .WithMany()
                .HasForeignKey(p => p.RolId);

            builder.HasMany(p => p.Permisos)
                .WithOne()
                .HasForeignKey(p => p.Id);
        }
    }
}
