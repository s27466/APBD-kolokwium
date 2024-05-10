using OrderApp.Models;
using OrderApp.Repositories;

namespace OrderApp.Services;

public class OrdersService : IOrdersService
{
    private readonly IOrdersRepository _ordersRepository;

    public OrdersService(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }
    public Order? GetOrder(int id)
    {
        return _ordersRepository.GetOrder(id);
    }
}