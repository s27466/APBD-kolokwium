using Microsoft.AspNetCore.Mvc;
using OrderApp.Services;

namespace OrderApp.Controllers;

[Route("api/order")]
[ApiController]
public class OrdersController : ControllerBase
{
    private IOrdersService _ordersService;

    public OrdersController(IOrdersService ordersService)
    {
        _ordersService = ordersService;
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetOrder(int id)
    {
        var order = _ordersService.GetOrder(id);

        if (order==null)
        {
            return NotFound("Student not found");
        }
        
        return Ok(order);
    }
}