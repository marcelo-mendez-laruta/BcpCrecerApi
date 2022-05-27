using System;
using ApiLib;
using ApiLib.Models;

namespace ApiLib
{
	public interface BcpContracts
	{
		LoginResponse Login(LoginRequest request);
		RegistroResponse Registro(RegistroRequest request);
		CategoriasResponse GetCategorias();
		EmpresasResponse GetEmpresas(EmpresasRequest request);
		ProductosResponse GetProductos(ProductosRequest request);
		bool SetProductos(Producto producto);
		bool SetEmpresa(Empresa empresa);
		bool SetCategoria(Categoria categoria);
	}
}

