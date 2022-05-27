
using System.Data.SqlClient;
using ApiLib;
using ApiLib.Models;

namespace ApiLib
{
    public class Services : BcpContracts
    {
        public string connectionstring;
        public Services()
        {
            //TODO: cambiar a variable de appsettings
            connectionstring = "Server=tcp:pirwasql.database.windows.net,1433;Initial Catalog=BcpCrecer;Persist Security Info=False;User ID=marcelo;Password=Videl240315!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
        public LoginResponse Login(LoginRequest request)
        {

            LoginResponse response = new LoginResponse("", "", "", "", "", "", "", "", "");
            using SqlConnection connection = new(connectionstring);
            using SqlCommand cmd = new("[BcpCrecer].Login", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", request.username);
            cmd.Parameters.AddWithValue("@Contrasena", request.password);
            connection.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    LoginResponse res = new LoginResponse
                    (
                        nombre: Convert.ToString(sdr["Nombre"]) == null ? "" : Convert.ToString(sdr["Nombre"])!,
                        paterno: Convert.ToString(sdr["Paterno"]) == null ? "" : Convert.ToString(sdr["Paterno"])!,
                        materno: Convert.ToString(sdr["Materno"]) == null ? "" : Convert.ToString(sdr["Materno"])!,
                        imagen: Convert.ToString(sdr["Imagen"]) == null ? "" : Convert.ToString(sdr["Imagen"])!,
                        fecnac: Convert.ToString(sdr["Fecnac"]) == null ? "" : Convert.ToString(sdr["Fecnac"])!,
                        idc: Convert.ToString(sdr["Idc"]) == null ? "" : Convert.ToString(sdr["Idc"])!,
                        tipoidc: Convert.ToString(sdr["Tipoidc"]) == null ? "" : Convert.ToString(sdr["Tipoidc"])!,
                        extidc: Convert.ToString(sdr["Extidc"]) == null ? "" : Convert.ToString(sdr["Extidc"])!,
                        complementoidc: Convert.ToString(sdr["Complementoidc"]) == null ? "" : Convert.ToString(sdr["Complementoidc"])!
                    );
                    response = res;
                }
            }
            connection.Close();
            return response;
        }
        public RegistroResponse Registro(RegistroRequest request)
        {

            RegistroResponse response = new RegistroResponse("", "", "", "", "", "", "", "", "");
            using SqlConnection connection = new(connectionstring);
            using SqlCommand cmd = new("[BcpCrecer].SignIn", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", request.username);
            cmd.Parameters.AddWithValue("@Contrasena", request.password);
            cmd.Parameters.AddWithValue("@Nombre", request.username);
            cmd.Parameters.AddWithValue("@Paterno", request.password);
            cmd.Parameters.AddWithValue("@Materno", request.username);
            cmd.Parameters.AddWithValue("@Imagen", request.password);
            cmd.Parameters.AddWithValue("@Fecnac", request.username);
            cmd.Parameters.AddWithValue("@Idc", request.password);
            cmd.Parameters.AddWithValue("@Tipoidc", request.username);
            cmd.Parameters.AddWithValue("@Extidc", request.password);
            cmd.Parameters.AddWithValue("@Complementoidc", request.username);
            connection.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    RegistroResponse res = new RegistroResponse
                    (
                        nombre: Convert.ToString(sdr["Nombre"]) == null ? "" : Convert.ToString(sdr["Nombre"])!,
                        paterno: Convert.ToString(sdr["Paterno"]) == null ? "" : Convert.ToString(sdr["Paterno"])!,
                        materno: Convert.ToString(sdr["Materno"]) == null ? "" : Convert.ToString(sdr["Materno"])!,
                        imagen: Convert.ToString(sdr["Imagen"]) == null ? "" : Convert.ToString(sdr["Imagen"])!,
                        fecnac: Convert.ToString(sdr["Fecnac"]) == null ? "" : Convert.ToString(sdr["Fecnac"])!,
                        idc: Convert.ToString(sdr["Idc"]) == null ? "" : Convert.ToString(sdr["Idc"])!,
                        tipoidc: Convert.ToString(sdr["Tipoidc"]) == null ? "" : Convert.ToString(sdr["Tipoidc"])!,
                        extidc: Convert.ToString(sdr["Extidc"]) == null ? "" : Convert.ToString(sdr["Extidc"])!,
                        complementoidc: Convert.ToString(sdr["Complementoidc"]) == null ? "" : Convert.ToString(sdr["Complementoidc"])!
                    );
                    response = res;
                }
            }
            connection.Close();
            return response;
        }
        public CategoriasResponse GetCategorias()
        {
            
            List<Categoria> Categorias=new();
            CategoriasResponse response = new CategoriasResponse(Categorias);
            using SqlConnection connection = new(connectionstring);
            using SqlCommand cmd = new("[BcpCrecer].GetCategorias", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            connection.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {                
                while (sdr.Read())
                {
                    Categorias.Add(new Categoria
                    (
                        CategoriaId: Convert.ToInt32(sdr["CategoriaId"]),
                        Nombre: Convert.ToString(sdr["Nombre"]) == null ? "" : Convert.ToString(sdr["Nombre"])!,
                        Imagen: Convert.ToString(sdr["Imagen"]) == null ? "" : Convert.ToString(sdr["Imagen"])!,
                        Color: Convert.ToString(sdr["Color"]) == null ? "" : Convert.ToString(sdr["Color"])!
                    ));
                    response = new CategoriasResponse(Categorias);
                }
            }
            connection.Close();
            return response;
        }
        public EmpresasResponse GetEmpresas(EmpresasRequest request)
        {

            List<Empresa> Empresas = new();
            EmpresasResponse response = new EmpresasResponse(Empresas);
            using SqlConnection connection = new(connectionstring);
            using SqlCommand cmd = new("[BcpCrecer].GetEmpresas", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoriaId", request.CategoriaId);
            connection.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    Empresas.Add(new Empresa
                    (
                        EmpresaId: Convert.ToInt32(sdr["EmpresaId"]),
                        Nombre: Convert.ToString(sdr["Nombre"]) == null ? "" : Convert.ToString(sdr["Nombre"])!,
                        Imagen: Convert.ToString(sdr["Imagen"]) == null ? "" : Convert.ToString(sdr["Imagen"])!,
                        Color: Convert.ToString(sdr["Color"]) == null ? "" : Convert.ToString(sdr["Color"])!,
                        CategoriaId: Convert.ToInt32(sdr["CategoriaId"])
                    ));
                    response = new EmpresasResponse(Empresas);
                }
            }
            connection.Close();
            return response;
        }
        public ProductosResponse GetProductos(ProductosRequest request)
        {

            List<Producto> Productos = new();
            ProductosResponse response = new ProductosResponse(Productos);
            using SqlConnection connection = new(connectionstring);
            using SqlCommand cmd = new("[BcpCrecer].GetProductosByEmpresaId", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpresaId", request.EmpresaId);
            connection.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    Productos.Add(new Producto
                    (
                        ProductoId: Convert.ToInt32(sdr["ProductoId"]),
                        Nombre: Convert.ToString(sdr["Nombre"]) == null ? "" : Convert.ToString(sdr["Nombre"])!,
                        Imagen: Convert.ToString(sdr["Imagen"]) == null ? "" : Convert.ToString(sdr["Imagen"])!,
                        Color: Convert.ToString(sdr["Color"]) == null ? "" : Convert.ToString(sdr["Color"])!,
                        Precio: Convert.ToDouble(sdr["Precio"]),
                        Descuento: Convert.ToDouble(sdr["Descuento"]),
                        Descripcion: Convert.ToString(sdr["Descripcion"]) == null ? "" : Convert.ToString(sdr["Descripcion"])!,
                        EmpresaId: Convert.ToInt32(sdr["EmpresaId"])
                    ));
                    response = new ProductosResponse(Productos);
                }
            }
            connection.Close();
            return response;
        }
        public bool SetProductos(Producto producto)
        {
            try
            {
                using SqlConnection connection = new(connectionstring);
                using SqlCommand cmd = new("[BcpCrecer].SetProductos", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Imagen", producto.Imagen);
                cmd.Parameters.AddWithValue("@Color", producto.Color);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                cmd.Parameters.AddWithValue("@Descuento", producto.Descuento);
                cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@EmpresaId", producto.Nombre);
                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                connection.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }            
        }
        public bool SetEmpresa(Empresa empresa)
        {
            try
            {
                using SqlConnection connection = new(connectionstring);
                using SqlCommand cmd = new("[BcpCrecer].SetEmpresa", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", empresa.Nombre);
                cmd.Parameters.AddWithValue("@Imagen", empresa.Imagen);
                cmd.Parameters.AddWithValue("@Color", empresa.Color);
                cmd.Parameters.AddWithValue("@CategoriaId", empresa.CategoriaId);
                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                connection.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool SetCategoria(Categoria categoria)
        {
            try
            {
                using SqlConnection connection = new(connectionstring);
                using SqlCommand cmd = new("[BcpCrecer].SetCategoria", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                cmd.Parameters.AddWithValue("@Imagen", categoria.Imagen);
                cmd.Parameters.AddWithValue("@Color", categoria.Color);
                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                connection.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}

