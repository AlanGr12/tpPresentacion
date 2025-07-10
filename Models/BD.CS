using Microsoft.Data.SqlClient;
using Dapper;     

public class BD{
private static string _connectionString = @"Server=localhost;Database=Presentacion;Integrated Security=True;TrustServerCertificate=True;";

public static int Login(string email, string contraseña){
  using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT Id FROM DatoPersonal WHERE Email = @email AND Contraseña = @contraseña";
            return db.QueryFirstOrDefault<int?>(sql, new { email, contraseña }) ?? -1;
        }
}
    public static DatoPersonal GetUsuario(int id)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM DatoPersonal WHERE Id = @id";
            return db.QueryFirstOrDefault<DatoPersonal>(sql, new { id });
        }
    }

       public static List<DatoFamiliar> GetDatoFamiliar(int idUsuario)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM DatoFamiliar WHERE IdUsuario = @idUsuario";
            return db.Query<DatoFamiliar>(sql, new { idUsuario }).AsList();
        }
    }

     public static List<DatoInteres> GetDatoInteres(int idUsuario)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM DatoInteres WHERE IdUsuario = @idUsuario";
            return db.Query<DatoInteres>(sql, new { idUsuario }).AsList();
        }
    }
}