using CommonCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommonInfraestructure.EntityConfigurations
{
    public class UsuarioEntityConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();

            builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(p => p.NombreUsuario).HasColumnName("nombre_usuario").IsRequired();
            builder.Property(p => p.Contrasena).HasColumnName("contrasena").IsRequired();
            builder.Property(p => p.RolId).HasColumnName("id_rol").IsRequired();
            builder.Property(p => p.IdSucursal).HasColumnName("id_sucursal").IsRequired();
            builder.Property(p => p.Activo).HasColumnName("activo").IsRequired();
            builder.Property(p => p.FechaCreacion).HasColumnName("fecha_creacion").IsRequired();
            builder.Property(p => p.UsuarioCreaId).HasColumnName("id_usuario_creacion").IsRequired();
            builder.Property(p => p.FechaUltimaActualizacion).HasColumnName("fecha_ultima_actualizacion").IsRequired(false);
            builder.Property(p => p.UsuarioActualizaId).HasColumnName("id_usuario_ultima_actualizacion").IsRequired(false);

            builder.HasOne(p => p.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(p => p.RolId)
                .HasPrincipalKey(r => r.Id);

            builder.HasOne(p => p.UsuarioActualiza)
                .WithMany()
                .HasForeignKey(p => p.UsuarioActualizaId)
                .HasPrincipalKey(u => u.Id);

            builder.HasOne(p => p.UsuarioCrea)
                .WithMany()
                .HasPrincipalKey(u => u.Id)
                .HasForeignKey(p => p.UsuarioCreaId);

            builder.HasOne(p => p.Sucursal)
                .WithMany()
                .HasPrincipalKey(u => u.Id)
                .HasForeignKey(p => p.IdSucursal);
        }
    }
}
