using CommonCore.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContabilidadInfraestructure.EntityConfigurations
{
    public class PersonaEntityConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("personas");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.Nombre).HasColumnName("nombre").IsRequired();
            builder.Property(p => p.Email).HasColumnName("email").IsRequired();
            builder.Property(p => p.Telefono).HasColumnName("telefono").IsRequired();
            builder.Property(p => p.SitioWeb).HasColumnName("sitio_web").IsRequired(false);
            builder.Property(p => p.IdTipoPersona).HasColumnName("id_tipo_persona").IsRequired();
            builder.Property(p => p.IdDatosFiscales).HasColumnName("id_datos_fiscales").IsRequired(false);
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

            builder.HasOne(p => p.DatosFiscales)
                .WithMany()
                .HasForeignKey(p => p.IdDatosFiscales);

            builder.HasOne(p => p.TipoPersona)
                .WithMany()
                .HasForeignKey(p => p.IdTipoPersona);
        }
    }
}
