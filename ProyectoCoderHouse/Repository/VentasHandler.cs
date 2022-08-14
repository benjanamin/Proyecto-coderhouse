using ProyectoCoderHouse.Models;
using System.Data.SqlClient;

namespace ProyectoCoderHouse.Repository
{
    public static class VentasHandler
    {
        public const string ConnectionString = "Server=BENJA;Database=SistemaGestion;Trusted_Connection=True";
        public static List<Venta> GetVentas()
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Venta", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();
                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();
                                ventas.Add(venta);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return ventas;
        }
    }
}
