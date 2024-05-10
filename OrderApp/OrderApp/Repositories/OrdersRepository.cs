using System.Data.SqlClient;
using OrderApp.Models;

namespace OrderApp.Repositories;

public class OrdersRepository : IOrdersRepository
{
    private IConfiguration _configuration;

    public OrdersRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public Order GetOrder(int id)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdOrder, Name, Description, date, IdClient FROM Order WHERE IdOrder = @IdOrder";
        cmd.Parameters.AddWithValue("@IdOrder", id);
        
        var dr = cmd.ExecuteReader();
        
        if (!dr.Read()) return null;
        
        var order = new Order
        {
            IdOrder = (int)dr["IdOrder"],
            Name = dr["Name"].ToString(),
            Description = dr["Description"].ToString(),
            date = (DateTime)dr["date"],
            IdClient = (int)dr["IdClient"],
        };
        
        return order;
    }
}