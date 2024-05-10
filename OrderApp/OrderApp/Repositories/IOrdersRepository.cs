using OrderApp.Models;

namespace OrderApp.Repositories;

public interface IOrdersRepository
{
    Order GetOrder(int id);
}