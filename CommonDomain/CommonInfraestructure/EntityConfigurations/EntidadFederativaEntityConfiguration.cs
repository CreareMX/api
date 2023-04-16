using CommonCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommonInfraestructure.EntityConfigurations
{
    public class EntidadFederativaEntityConfiguration : IEntityTypeConfiguration<EntidadFederativa>
    {
        public void Configure(EntityTypeBuilder<EntidadFederativa> builder)
        {
            builder.ToTable("EntidadFederativas");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.Nombre).HasColumnName("Nombre").IsRequired();
        }
    }
}
