using Microsoft.Data.SqlClient;
using Dapper;     

public class BD{
private static string _connectionString = @"Server=localhost;Database=bdtpresentacion;Integrated Security=True;TrustServerCertificate=True;";

public static int Login(string email, string contraseña){
  using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string Query = "SELECT Id FROM DatoPersonal WHERE Email = @email AND Contraseña = @contraseña";
            return db.QueryFirstOrDefault<int>(Query, new { email, contraseña });
        }
}
    public static DatoPersonal GetUsuario(int id)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string Query = "SELECT * FROM DatoPersonal WHERE Id = @id";
            return db.QueryFirstOrDefault<DatoPersonal>(Query, new { id });
        }
    }

       public static List<DatoFamiliar> GetDatoFamiliar(int idUsuario)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string Query = "SELECT * FROM DatoFamiliar WHERE IdUsuario = @idUsuario";
            return db.Query<DatoFamiliar>(Query, new { idUsuario }).AsList();
        }
    }

     public static List<DatoInteres> GetDatoInteres(int idUsuario)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string Query = "SELECT * FROM DatoInteres WHERE IdUsuario = @idUsuario";
            return db.Query<DatoInteres>(Query, new { idUsuario }).AsList();
        }
    }
}