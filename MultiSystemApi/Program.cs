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
#endregion

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterAssemblyTypes(new List<Assembly> {
        essentialCoreAssembly,
        essentialInfraestructureAssembly,
        essentialApplicationAssembly,
        executingAssembly,
        commonCoreAssembly,
        commonInfraestructureAssembly,
        commonApplicationAssembly 
    }.ToArray()).AsImplementedInterfaces();
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(new List<Assembly> { commonApplicationAssembly });
builder.Services.AddDbContext<SqlServerDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.Services.GetService<SqlServerDbContext>()?.AddConfigurations(commonInfraestructureAssembly);

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
