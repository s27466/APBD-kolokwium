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
        int affectedCount = 0;

        using (var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
        {
            con.Open();
            var transaction = con.BeginTransaction();

            try
            {
                using (var cmdDeleteOrders = new SqlCommand("DELETE FROM [Order] WHERE IdClient = @IdClient", con, transaction))
                {
                    cmdDeleteOrders.Parameters.AddWithValue("@IdClient", idClient);
                    affectedCount += cmdDeleteOrders.ExecuteNonQuery();
                }
                
                using (var cmdDeleteOrderProducts = new SqlCommand("DELETE FROM Order_Product WHERE IdOrder NOT IN (SELECT IdOrder FROM [Order])", con, transaction))
                {
                    affectedCount += cmdDeleteOrderProducts.ExecuteNonQuery();
                }
                
                using (var cmdDeleteClient = new SqlCommand("DELETE FROM [Client] WHERE IdClient = @IdClient", con, transaction))
                {
                    cmdDeleteClient.Parameters.AddWithValue("@IdClient", idClient);
                    affectedCount += cmdDeleteClient.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        return affectedCount;
    }

}