using ComprasCore.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComprasInfraestructure.EntityConfigurations
{
    public class OrdenCompraEntityConfiguration : IEntityTypeConfiguration<OrdenCompra>
    {
        public void Configure(EntityTypeBuilder<OrdenCompra> builder)
        {
            builder.ToTable("ordenes");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.IdCliente).HasColumnName("id_cliente").IsRequired();
            builder.Property(p => p.IdEmpleadoCrea).HasColumnName("id_empleado_crea").IsRequired();
            builder.Property(p => p.IdEmpleadoAutoriza).HasColumnName("id_empleado_autoriza").IsRequired();
            builder.Property(p => p.Fecha).HasColumnName("fecha").IsRequired();
            builder.Property(p => p.FechaCompromiso).HasColumnName("fecha_compromiso").IsRequired();
            builder.Property(p => p.FechaEnvio).HasColumnName("fecha_envio").IsRequired();
            builder.Property(p => p.FechaAutorizacion).HasColumnName("fecha_autorizacion").IsRequired();
            builder.Property(p => p.FormaEnvio).HasColumnName("forma_envio").IsRequired();
            builder.Property(p => p.IdSucursal).HasColumnName("id_sucursal").IsRequired();
            builder.Property(p => p.Comentarios).HasColumnName("comentarios").IsRequired(false);
            builder.Property(p => p.IdEstado).HasColumnName("id_estado").IsRequired();
            builder.Property(p => p.Activo).HasColumnName("activo").IsRequired();
            builder.Property(p => p.FechaCreacion).HasColumnName("fecha_creacion").IsRequired();
            builder.Property(p => p.UsuarioCreaId).HasColumnName("id_usuario_creacion").IsRequired();
            builder.Property(p => p.FechaUltimaActualizacion).HasColumnName("fecha_ultima_actualizacion").IsRequired(false);
            builder.Property(p => p.UsuarioActualizaId).HasColumnName("id_usuario_ultima_actualizacion").IsRequired(false);
            builder.Property(p => p.IdAlmacen).HasColumnName("id_almacen").IsRequired();

            builder.HasOne(p => p.UsuarioCrea)
                .WithMany()
                .HasForeignKey(p => p.UsuarioCreaId);

            builder.HasOne(p => p.UsuarioActualiza)
                .WithMany()
                .HasForeignKey(p => p.UsuarioActualizaId);

            builder.HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.IdCliente);

            builder.HasOne(p => p.EmpleadoCrea)
                .WithMany()
                .HasForeignKey(p => p.IdEmpleadoCrea);

            builder.HasOne(p => p.Estado)
                .WithMany()
                .HasForeignKey(p => p.IdEstado);

            builder.HasOne(p => p.Sucursal)
                .WithMany()
                .HasForeignKey(p => p.IdSucursal);

            builder.HasOne(p => p.Almacen)
                .WithMany()
                .HasForeignKey(p => p.IdAlmacen);

            builder.HasOne(p => p.EmpleadoAutoriza)
                .WithMany()
                .HasForeignKey(p => p.IdEmpleadoAutoriza);

            builder.HasMany(p => p.Detalles)
                .WithOne(p => p.OrdenCompra)
                .HasForeignKey(p => p.IdOrdenCompra)
                .HasPrincipalKey(p => p.Id);
        }
    }
}
