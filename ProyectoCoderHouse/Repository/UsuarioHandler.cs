using ProyectoCoderHouse.Models;
using System.Data.SqlClient;

namespace ProyectoCoderHouse.Repository
{
    public static class UsuarioHandler
    {
        public const string ConnectionString = "Server=BENJA;Database=SistemaGestion;Trusted_Connection=True";

        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
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
                                Usuario usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                usuario.Mail = dataReader["Mail"].ToString();

                                usuarios.Add(usuario);

                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return usuarios;
        }
        public static Usuario GetUsuarioByNombreUsuarioAndContraseña(string nombreUsuario, string contraseña)
        {
            Usuario usuario = new Usuario();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario " + 
                    "WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contraseña", sqlConnection))
                {
                    sqlConnection.Open();

                    SqlParameter parametro = new SqlParameter();
                    parametro.ParameterName = "nombreUsuario";
                    parametro.SqlDbType = System.Data.SqlDbType.VarChar;
                    parametro.Value = nombreUsuario;
                    sqlCommand.Parameters.Add(parametro);

                    SqlParameter parametro2 = new SqlParameter();
                    parametro2.ParameterName = "contraseña";
                    parametro2.SqlDbType = System.Data.SqlDbType.VarChar;
                    parametro2.Value = contraseña;

                    sqlCommand.Parameters.Add(parametro2);
                    
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                usuario.Mail = dataReader["Mail"].ToString();
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return usuario;

        }
    }
}
