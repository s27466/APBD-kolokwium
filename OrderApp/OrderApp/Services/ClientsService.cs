using OrderApp.Repositories;

namespace OrderApp.Services;

public class ClientsService : IClientsService
{
    private readonly IClientsRepository _clientsRepository;

    public ClientsService(IClientsRepository clientsRepository)
    {
        _clientsRepository = clientsRepository;
    }

    public int DeleteClient(int idClient)
    {
        return _clientsRepository.DeleteClient(idClient);
    }
}