using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommonApplication.Dtos;
using EssentialCore.DbContexts;
using EssentialCore.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

try
{
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

    var almacenCoreAssembly = Assembly.Load(new AssemblyName("AlmacenCore"));
    var almacenInfraestructureAssembly = Assembly.Load(new AssemblyName("AlmacenInfraestructure"));
    var almacenApplicationAssembly = Assembly.Load(new AssemblyName("AlmacenApplication"));

    var ventasCoreAssembly = Assembly.Load(new AssemblyName("VentasCore"));
    var ventasInfraestructureAssembly = Assembly.Load(new AssemblyName("VentasInfraestructure"));
    var ventasApplicationAssembly = Assembly.Load(new AssemblyName("VentasApplication"));

    var comprasCoreAssembly = Assembly.Load(new AssemblyName("ComprasCore"));
    var comprasInfraestructureAssembly = Assembly.Load(new AssemblyName("ComprasInfraestructure"));
    var comprasApplicationAssembly = Assembly.Load(new AssemblyName("ComprasApplication"));
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
        rrhhApplicationAssembly,
        almacenCoreAssembly,
        almacenInfraestructureAssembly,
        almacenApplicationAssembly,
        ventasCoreAssembly,
        ventasInfraestructureAssembly,
        ventasApplicationAssembly,
        comprasCoreAssembly,
        comprasInfraestructureAssembly,
        comprasApplicationAssembly,
        }.ToArray()).AsImplementedInterfaces();

        var optionsBuilder = new DbContextOptionsBuilder<SqlServerDbContext>();
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        var jwt = builder.Configuration.GetSection("Jwt").Get<Jwt>();

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        var context = new SqlServerDbContext(optionsBuilder.Options);
        context.AddConfigurations(commonInfraestructureAssembly);
        context.AddConfigurations(essentialInfraestructureAssembly);
        context.AddConfigurations(contabilidadInfraestructureAssembly);
        context.AddConfigurations(rrhhInfraestructureAssembly);
        context.AddConfigurations(almacenInfraestructureAssembly);
        context.AddConfigurations(ventasInfraestructureAssembly);
        context.AddConfigurations(comprasInfraestructureAssembly);

        containerBuilder.RegisterInstance(context).AsSelf();
        containerBuilder.RegisterInstance(jwt).AsImplementedInterfaces();
    });

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = $"Creare API - MultiSystem [{builder.Environment.EnvironmentName}]",
            Version = "v1"
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "La autorizacion JWT usa el esquema Bearer. \r\n\r\nEscriba 'bearer' [espacio] y luego el valore del token de autorización.\r\n\r\nPor ejemplo: \"bearer 1safsfsdfdfd\"",
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
    });
    builder.Services.AddAutoMapper(new List<Assembly> {
    commonApplicationAssembly,
    essentialApplicationAssembly,
    contabilidadApplicationAssembly,
    rrhhApplicationAssembly,
    almacenApplicationAssembly,
    ventasApplicationAssembly,
    comprasApplicationAssembly
});
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("MyAllowSpecificOrigins", policy =>
        {
            policy.WithOrigins(new[] {
            "http://localhost:3000",
            "http://localhost:5000",
            "http://localhost:5001",
            "http://localhost:5002",
            "http://18.189.205.28",
            "http://18.189.205.28:82",
            "http://18.189.205.28:83",
            "https://mayoreodeloriente.netlify.app",
            "https://cnseguridad.netlify.app"
            });
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
    });
    builder.Services.AddAuthorization();


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.EnvironmentName.Contains("Development"))
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
        app.UseHttpsRedirection();

    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    });

    app.UseCors("MyAllowSpecificOrigins");
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}catch(Exception ex)
{
    Console.WriteLine("Errores del sistema:");
    Console.WriteLine(ex.Message);
    if(ex.InnerException != null)
        Console.WriteLine(ex.InnerException.Message);
}