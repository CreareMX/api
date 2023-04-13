using CommonCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommonInfraestructure.EntityConfigurations
{
    public class ProductoEntityConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.Name).HasColumnName("Nombre").IsRequired();
            builder.Property(p => p.ShortName).HasColumnName("NombreCorto").IsRequired(false);
            builder.Property(p => p.BarCode).HasColumnName("CodigoBarras").IsRequired();
            builder.Property(p => p.ShortCode).HasColumnName("CodigoCorto").IsRequired(false);
            builder.Property(p => p.IsActive).HasColumnName("Activo").IsRequired();
            builder.Property(p => p.CreationDate).HasColumnName("FechaCreacion").IsRequired();
            builder.Property(p => p.CreationUser).HasColumnName("UsuarioCreacion").IsRequired();
            builder.Property(p => p.LastUpdateDate).HasColumnName("FechaUltimaActualizacion").IsRequired(false);
            builder.Property(p => p.LastUpdateUser).HasColumnName("UsuarioUltimaActualizacion").IsRequired(false);
        }
    }
}
