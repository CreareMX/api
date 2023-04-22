using Autofac;
using Autofac.Extensions.DependencyInjection;
using EssentialCore.DbContexts;
using EssentialCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var entity = typeof(BaseEntityLongId).Assembly;

#region ASSAMBLIES
var essentialCoreAssembly = Assembly.Load(new AssemblyName("EssentialCore"));
var essentialInfraestructureAssembly = Assembly.Load(new AssemblyName("EssentialInfraestructure"));
var essentialApplicationAssembly = Assembly.Load(new AssemblyName("EssentialApplication"));
var executingAssembly = Assembly.GetExecutingAssembly();

var commonCoreAssembly = Assembly.Load(new AssemblyName("CommonCore"));
var commonInfraestructureAssembly = Assembly.Load(new AssemblyName("CommonInfraestructure"));
var commonApplicationAssembly = Assembly.Load(new AssemblyName("CommonApplication"));

var contabilidadCoreAssembly = Assembly.Load(new AssemblyName("ContabilidadCore"));
var contabilidadInfraestructureAssembly = Assembly.Load(new AssemblyName("ContabilidadInfraestructure"));
var contabilidadApplicationAssembly = Assembly.Load(new AssemblyName("ContabilidadApplication"));

var rrhhCoreAssembly = Assembly.Load(new AssemblyName("RRHHCore"));
var rrhhInfraestructureAssembly = Assembly.Load(new AssemblyName("RRHHInfraestructure"));
var rrhhApplicationAssembly = Assembly.Load(new AssemblyName("RRHHApplication"));
#endregion

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterAssemblyTypes(new List<Assembly> {
        essentialCoreAssembly,
        essentialInfraestructureAssembly,
        essentialApplicationAssembly,
        executingAssembly,
        commonCoreAssembly,
        commonInfraestructureAssembly,
        commonApplicationAssembly,
        contabilidadCoreAssembly,
        contabilidadInfraestructureAssembly,
        contabilidadApplicationAssembly,
        rrhhCoreAssembly,
        rrhhInfraestructureAssembly,
        rrhhApplicationAssembly
    }.ToArray()).AsImplementedInterfaces();

    var optionsBuilder = new DbContextOptionsBuilder<SqlServerDbContext>();
    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

    var context = new SqlServerDbContext(optionsBuilder.Options);
    context.AddConfigurations(commonInfraestructureAssembly);
    context.AddConfigurations(essentialInfraestructureAssembly);
    context.AddConfigurations(contabilidadInfraestructureAssembly);
    context.AddConfigurations(rrhhInfraestructureAssembly);

    containerBuilder.RegisterInstance(context).AsSelf();
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => {
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddAutoMapper(new List<Assembly> { 
    commonApplicationAssembly,
    essentialApplicationAssembly,
    contabilidadApplicationAssembly,
    rrhhApplicationAssembly
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
