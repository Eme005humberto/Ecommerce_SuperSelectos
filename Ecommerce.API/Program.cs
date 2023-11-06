using Ecommerce.Repositorio.DBContext;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Repositorio.Contrato;
using Ecommerce.Repositorio.Implementacion;
using Ecommerce.Utilidades;
using Ecommerce.Servicio.Contrato;
using Ecommerce.Servicio.Implementacion;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Vamos a implemetar nuestro servicio de base de datos
builder.Services.AddDbContext<DbEcommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Ecommerce"));
});
builder.Services.AddTransient(typeof(IGenericoRepositorio<>),typeof(GenericoRepositorio<>));
builder.Services.AddScoped<IVentaRepositorio, VentaRepositorio>();

builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();
builder.Services.AddScoped<IVentaServicio, VentasServicio>();
builder.Services.AddScoped<IDashboardServicio,DashboardServicio>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().//Cualquier origen
        AllowAnyHeader().
        AllowAnyMethod();
    });
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("NuevaPolitica");//Podemos ejecutar la Api y La web Cliente en el mismo URL

app.UseAuthorization();

app.MapControllers();

app.Run();
