using ContabilidadCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContabilidadInfraestructure.EntityConfigurations
{
    public class DatosFiscalesEntityConfiguration : IEntityTypeConfiguration<DatosFiscales>
    {
        public void Configure(EntityTypeBuilder<DatosFiscales> builder)
        {
            builder.ToTable("datos_fiscales");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.RazonSocial).HasColumnName("razon_social").IsRequired(false);
            builder.Property(p => p.Rfc).HasColumnName("rfc").IsRequired(false);
            builder.Property(p => p.Nombres).HasColumnName("nombres").IsRequired(false);
            builder.Property(p => p.ApellidoPaterno).HasColumnName("apellido_paterno").IsRequired(false);
            builder.Property(p => p.ApellidoMaterno).HasColumnName("apellido_materno").IsRequired(false);
            builder.Property(p => p.Calle).HasColumnName("calle").IsRequired(false);
            builder.Property(p => p.NumeroExterior).HasColumnName("numero_exterior").IsRequired(false);
            builder.Property(p => p.NumeroInterior).HasColumnName("numero_interior").IsRequired(false);
            builder.Property(p => p.Cruzamientos).HasColumnName("cruzamientos").IsRequired(false);
            builder.Property(p => p.Domicilio).HasColumnName("domicilio").IsRequired(false);
            builder.Property(p => p.Colonia).HasColumnName("colonia").IsRequired(false);
            builder.Property(p => p.CodigoPostal).HasColumnName("codigo_postal").IsRequired();
            builder.Property(p => p.IdEntidadFederativa).HasColumnName("id_entidad_federativa").IsRequired();
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

            builder.HasOne(p => p.EntidadFederativa)
                .WithMany()
                .HasForeignKey(p => p.IdEntidadFederativa);
        }
    }
}
