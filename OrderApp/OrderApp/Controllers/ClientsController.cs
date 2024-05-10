using Microsoft.AspNetCore.Mvc;
using OrderApp.Services;

namespace OrderApp.Controllers;

[Route("api/client")]
[ApiController]
public class ClientsController : ControllerBase
{
    private IClientsService _clientsService;

    public ClientsController(IClientsService clientsService)
    {
        _clientsService = clientsService;
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteClient(int id)
    {
        var affectedCount = _clientsService.DeleteClient(id);
        return NoContent();
    }
}