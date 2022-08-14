using ProyectoCoderHouse.Models;
using System.Data.SqlClient;

namespace ProyectoCoderHouse.Repository
{
    public class ProductoHandler


    {
        public const string ConnectionString = "Server=BENJA;Database=SistemaGestion;Trusted_Connection=True";

        public static List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto ", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Producto producto = new Producto();
                                producto.Id = Convert.ToInt32(dataReader["Id"]);
                                producto.Descripciones = dataReader["Descripciones"].ToString();
                                producto.Costo = Convert.ToInt64(dataReader["Costo"]);
                                producto.PrecioVenta = Convert.ToInt64(dataReader["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                                productos.Add(producto);
                            }
                        }
                    }
                }
            }
            return productos;
        }
        /*
            public const string ConnectionString = "Server=BENJA;Database=SistemaGestion;Trusted_Connection=True";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
             {
                 using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario ", sqlConnection))
                 {
                     sqlConnection.Open();
                     using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                     {
                         if(dataReader.HasRows)
                         {
                             while (dataReader.Read())
                             {

                             }
                         }
                     }
                 }
             }
         */
    }
}
