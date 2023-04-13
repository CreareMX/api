using CommonCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommonInfraestructure.EntityConfigurations
{
    public class UsuarioEntityConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.Username).HasColumnName("NumbreUsuario").IsRequired();
            builder.Property(p => p.Password).HasColumnName("Contrasena").IsRequired();
            builder.Property(p => p.IsActive).HasColumnName("Activo").IsRequired();
            builder.Property(p => p.CreationDate).HasColumnName("FechaCreacion").IsRequired();
            builder.Property(p => p.CreationUser).HasColumnName("UsuarioCreacion").IsRequired();
            builder.Property(p => p.LastUpdateDate).HasColumnName("FechaUltimaActualizacion").IsRequired(false);
            builder.Property(p => p.LastUpdateUser).HasColumnName("UsuarioUltimaActualizacion").IsRequired(false);
        }
    }
}
