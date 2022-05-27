using ApiLib;
using ApiLib.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BcpContracts, Services>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.MapPost("/login", (LoginRequest request, BcpContracts bcpContracts) =>
{
    var response = bcpContracts.Login(request);
    return response;
})
.WithName("login");
app.MapPost("/registro", (RegistroRequest request, BcpContracts bcpContracts) =>
{
    var response = bcpContracts.Registro(request);
    return response;
})
.WithName("registro");
app.MapGet("/categorias", (BcpContracts bcpContracts) =>
{
    var response = bcpContracts.GetCategorias();
    return response;
})
.WithName("categorias");
app.MapPost("/empresas", (EmpresasRequest request, BcpContracts bcpContracts) =>
{
    var response = bcpContracts.GetEmpresas(request);
    return response;
})
.WithName("empresas");
app.MapPost("/productos", (ProductosRequest request, BcpContracts bcpContracts) =>
{
    var response = bcpContracts.GetProductos(request);
    return response;
})
.WithName("productos");
app.MapPost("/nuevoproducto", (Producto producto, BcpContracts bcpContracts) =>
{
    var response = bcpContracts.SetProductos(producto);
    return response;
})
.WithName("nuevoproducto");
app.MapPost("/nuevacategoria", (Categoria categoria, BcpContracts bcpContracts) =>
{
    var response = bcpContracts.SetCategoria(categoria);
    return response;
})
.WithName("nuevacategoria");
app.MapPost("/nuevaempresa", (Empresa empresa, BcpContracts bcpContracts) =>
{
    var response = bcpContracts.SetEmpresa(empresa);
    return response;
})
.WithName("nuevaempresa");

app.Run();

record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
