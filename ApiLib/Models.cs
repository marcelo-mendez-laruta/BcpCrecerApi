namespace ApiLib.Models
{
	public record LoginRequest(string username,string password);
	public record LoginResponse(string nombre,	string paterno,	string materno,	string imagen,	string fecnac,	string idc,string tipoidc,	string extidc,	string complementoidc);
	public record RegistroRequest(string username, string password,string nombre, string paterno, string materno, string imagen, string fecnac, string idc, string tipoidc, string extidc, string complementoidc);
	public record RegistroResponse(string nombre, string paterno, string materno, string imagen, string fecnac, string idc, string tipoidc, string extidc, string complementoidc);
	public record CategoriasResponse(List<Categoria> Categorias);
	public record Categoria(int? CategoriaId, string Nombre, string Imagen, string Color);
	public record Empresa(int? EmpresaId, string Nombre, string Imagen, string Color, int CategoriaId);
	public record EmpresasRequest(int CategoriaId);
	public record EmpresasResponse(List<Empresa> Empresas);
	public record Producto(int? ProductoId,string Nombre, string Imagen, string Color, double Precio, double Descuento,string Descripcion,int EmpresaId);
	public record ProductosRequest(int EmpresaId);
	public record ProductosResponse(List<Producto> Productos);
}

