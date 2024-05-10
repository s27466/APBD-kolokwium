using OrderApp.Models;

namespace OrderApp.Services;

public interface IOrdersService
{
    Order? GetOrder(int id);
}