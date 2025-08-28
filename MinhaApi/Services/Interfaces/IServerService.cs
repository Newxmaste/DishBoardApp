using MinhaApi.Models;
using MinhaApi.DTO;

public interface IServerService
{
    List<Server> GetAllServers();
    Server? GetServerById(Guid id);
    Server AddServer(AddServerDto dto);
    bool DeleteServer(Guid id);
    bool UpdateServer(Guid id, UpdateServerDto dto);
}