using ProyectoCoderHouse.Models;
using System.Data.SqlClient;

namespace ProyectoCoderHouse.Repository
{
    public static class ProductoVendidoHandler
    {
        public const string ConnectionString = "Server=BENJA;Database=SistemaGestion;Trusted_Connection=True";
        
        public static List<ProductoVendido> GetProductosVendidos()
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ProductoVendido ", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();
                                productoVendido.IdProducto = Convert.ToInt32(dataReader["Id"]);
                                productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);
                                productosVendidos.Add(productoVendido);
                            }
                        }
                    }
                    sqlConnection.Close();
                    return productosVendidos;
                }
            }
        }
    }
}
