using Microsoft.Data.SqlClient;
using Dapper;     

public class BD{
private static string _connectionString = @"Server=localhost;Database=bdtpresentacion;Integrated Security=True;TrustServerCertificate=True;";

public static int Login(string email, string contraseña){
  using (SqlConnection connection= new SqlConnection(_connectionString))
        {
            string Query = "SELECT Id FROM DatoPersonal WHERE Email = @email AND Contraseña = @contraseña";
            return connection.QueryFirstOrDefault<int>(Query, new { email, contraseña });
        }
}
    public static DatoPersonal GetUsuario(int id)
    {       
        DatoPersonal Usuario = null;
         using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string Query = "SELECT * FROM DatoPersonal WHERE Id = @id";
            Usuario = connection.QueryFirstOrDefault<DatoPersonal>(Query, new { id });
        }
        return Usuario;
    }

       public static List<DatoFamiliar> GetDatoFamiliar(int idUsuario)
    {   
        List<DatoFamiliar> familiares = new List<DatoFamiliar>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string Query = "SELECT * FROM DatoFamiliar WHERE IdUsuario = @idUsuario";
            familiares = connection.Query<DatoFamiliar>(Query, new { idUsuario }).ToList();
        }

        return familiares;
    }

     public static List<DatoInteres> GetDatoInteres(int idUsuario)
    {   
        List<DatoInteres> intereses = new List<DatoInteres>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string Query = "SELECT * FROM DatoInteres WHERE IdUsuario = @idUsuario";
            intereses = connection.Query<DatoInteres>(Query, new { idUsuario }).ToList();
        }

        return intereses;

       
    }
}