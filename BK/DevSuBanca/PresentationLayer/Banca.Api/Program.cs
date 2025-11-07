using BancaNegocio;
using Configuracion;
using Contexto;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BancaContexto>(options =>
    options
        .UseLazyLoadingProxies()
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(NuevoClienteHandler).Assembly)
);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MediatRTransaccionHandler<,>));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
      .AllowAnyHeader()
      .AllowAnyMethod();
        });
});


var app = builder.Build();

app.UseMiddleware<HandlerExceptionMiddleware>();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();

app.MapGet("/", () => "API está funcionando");

app.Run();
