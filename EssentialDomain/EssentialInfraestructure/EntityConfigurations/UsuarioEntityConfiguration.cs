using EssentialCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EssentialInfraestructure.EntityConfigurations
{
    public class UsuarioEntityConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.NombreUsuario).HasColumnName("NumbreUsuario").IsRequired();
            builder.Property(p => p.Contrasena).HasColumnName("Contrasena").IsRequired();
            builder.Property(p => p.Activo).HasColumnName("Activo").IsRequired();
            builder.Property(p => p.FehaCreacion).HasColumnName("FechaCreacion").IsRequired();
            builder.Property(p => p.UsuarioCreaId).HasColumnName("UsuarioCreacion").IsRequired();
            builder.Property(p => p.FechaUltimaActualizacion).HasColumnName("FechaUltimaActualizacion").IsRequired(false);
            builder.Property(p => p.UsuarioActualizaId).HasColumnName("UsuarioUltimaActualizacion").IsRequired(false);
        }
    }
}
