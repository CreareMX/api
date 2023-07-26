using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommonApplication.Dtos;
using CommonCore.DbContexts;
using CommonCore.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MultiSystemApi;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

try
{
    var entity = typeof(BaseEntityLongId).Assembly;

    #region ASSAMBLIES
    var executingAssembly = Assembly.GetExecutingAssembly();
    var commonCoreAssembly = Assembly.Load(new AssemblyName("CommonCore"));
    var infraestructures = new List<Assembly> {
        Assembly.Load(new AssemblyName("ContabilidadInfraestructure")),
        Assembly.Load(new AssemblyName("CommonInfraestructure")),
        Assembly.Load(new AssemblyName("RRHHInfraestructure")),
        Assembly.Load(new AssemblyName("AlmacenInfraestructure")),
        Assembly.Load(new AssemblyName("VentasInfraestructure")),
        Assembly.Load(new AssemblyName("ComprasInfraestructure"))
    };
    var applications = new List<Assembly> {
        Assembly.Load(new AssemblyName("CommonApplication")),
        Assembly.Load(new AssemblyName("ContabilidadApplication")),
        Assembly.Load(new AssemblyName("RRHHApplication")),
        Assembly.Load(new AssemblyName("AlmacenApplication")),
        Assembly.Load(new AssemblyName("VentasApplication")),
        Assembly.Load(new AssemblyName("ComprasApplication"))
    };
    #endregion
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    var corsOrigins = builder.Configuration.GetSection("cors_origins").Get<string[]>();

    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        var assemblies = new List<Assembly> {
            executingAssembly,
            commonCoreAssembly
        };
        assemblies.AddRange(infraestructures);
        assemblies.AddRange(applications);
        containerBuilder.RegisterAssemblyTypes(assemblies.ToArray()).AsImplementedInterfaces();

        var optionsBuilder = new DbContextOptionsBuilder<SqlServerDbContext>();
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        var jwt = builder.Configuration.GetSection("Jwt").Get<Jwt>();

        try
        {
            File.AppendAllText(Path.Combine(AppContext.BaseDirectory, "my_log.txt"), $"{DateTime.Now:dd-MM-yyyy HH:mm:ss}{Environment.NewLine}{connectionString}{Environment.NewLine}{Environment.NewLine}");
        }
        catch
        {
            Console.WriteLine(connectionString);
        }
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        var context = new SqlServerDbContext(optionsBuilder.Options);
        foreach(var assm in infraestructures)
            context.AddConfigurations(assm);

        containerBuilder.RegisterInstance(context).AsSelf();
        containerBuilder.RegisterInstance(jwt).AsImplementedInterfaces();
    });

    builder.Services.AddControllers().AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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
            Description = "La autorizacion JWT usa el esquema Bearer. \r\n\r\nEscriba 'bearer' [espacio] y luego el valore del token de autorización.\r\n\r\nPor ejemplo: \"bearer 1safsfsdfdfd\""
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
            {
                new OpenApiSecurityScheme {
                    Reference = new OpenApiReference {
                        Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    });
    builder.Services.AddAutoMapper(applications);
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
            policy.WithOrigins(corsOrigins.ToArray());
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
    });
    builder.Services.AddAuthorization();


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.EnvironmentName.Contains("Development") || app.Environment.EnvironmentName.Contains("Local"))
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
    File.AppendAllText(Path.Combine(AppContext.BaseDirectory, "my_log.txt"), $"{DateTime.Now:dd-MM-yyyy HH:mm:ss}{Environment.NewLine}{MultiSystemException.ExMessage(ex)}{Environment.NewLine}- {ex.StackTrace}{Environment.NewLine}{Environment.NewLine}");

    Console.WriteLine("Errores del sistema:");
    Console.WriteLine(ex.Message);
    if(ex.InnerException != null)
        Console.WriteLine(ex.InnerException.Message);
}