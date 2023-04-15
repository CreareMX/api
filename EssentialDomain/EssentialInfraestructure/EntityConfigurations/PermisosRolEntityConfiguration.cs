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
            builder.Property(p => p.RolId).HasColumnName("id_rol").IsRequired();
            builder.Property(p => p.PermisoId).HasColumnName("id_permiso").IsRequired();
            builder.Property(p => p.Activo).HasColumnName("activo").IsRequired();
            builder.Property(p => p.FechaCreacion).HasColumnName("fecha_creacion").IsRequired();
            builder.Property(p => p.UsuarioCreaId).HasColumnName("id_usuario_creacion").IsRequired();
            builder.Property(p => p.FechaUltimaActualizacion).HasColumnName("fecha_ultima_actualizacion").IsRequired(false);
            builder.Property(p => p.UsuarioActualizaId).HasColumnName("id_usuario_ultima_actualizacion").IsRequired(false);

            builder.HasOne(p => p.UsuarioCrea)
                .WithMany()
                .HasForeignKey(p => p.UsuarioCreaId)
                .HasPrincipalKey(p => p.Id);

            builder.HasOne(p => p.UsuarioActualiza)
                .WithMany()
                .HasForeignKey(p => p.UsuarioActualizaId)
                .HasPrincipalKey(p => p.Id);

            builder.HasOne(p => p.Rol)
                .WithMany()
                .HasForeignKey(p => p.RolId)
                .HasPrincipalKey(p => p.Id);

            builder.HasOne(p => p.Permiso)
                .WithMany()
                .HasForeignKey(p => p.PermisoId)
                .HasPrincipalKey(p => p.Id);
        }
    }
}
