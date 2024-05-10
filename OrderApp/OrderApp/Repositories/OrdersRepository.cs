using System.Data.SqlClient;
using OrderApp.Models;

namespace OrderApp.Repositories;

public class OrdersRepository : IOrdersRepository
{
    private readonly IConfiguration _configuration;

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
        cmd.CommandText = @"
            SELECT o.IdOrder, o.Name, o.Description, o.CreationDate, o.IdClient, p.IdProduct, p.Name AS ProductName, op.Quantity
            FROM [Order] o
            INNER JOIN [Order_Product] op ON o.IdOrder = op.IdOrder
            INNER JOIN [Product] p ON op.IdProduct = p.IdProduct
            WHERE o.IdOrder = @IdOrder";
        cmd.Parameters.AddWithValue("@IdOrder", id);
    
        var dr = cmd.ExecuteReader();
    
        Order order = null;
        while (dr.Read())
        {
            order ??= new Order
            {
                IdOrder = (int)dr["IdOrder"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                CreationDate = (DateTime)dr["CreationDate"],
                IdClient = (int)dr["IdClient"],
                Products = new List<Product>()
            };

            order.Products.Add(new Product
            {
                IdProduct = (int)dr["IdProduct"],
                Name = dr["ProductName"].ToString(),
                Price = (float)dr["Price"],
                Quantity = (int)dr["Quantity"]
            });
        }
    
        return order;
    }

}