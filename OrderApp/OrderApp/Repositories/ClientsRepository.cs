using System.Data.SqlClient;

namespace OrderApp.Repositories;

public class ClientsRepository : IClientsRepository
{
    private IConfiguration _configuration;

    public ClientsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public int DeleteClient(int idClient)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Student WHERE IdStudent = @IdStudent";
        cmd.Parameters.AddWithValue("@IdStudent", idClient);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}