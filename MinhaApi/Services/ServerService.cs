using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Internal;
using MinhaApi.Data;
using MinhaApi.DTO;
using MinhaApi.Models;

public class ServerService : IServerService
{
    private readonly DishBoardProdContext dbContext;

    public ServerService(DishBoardProdContext dbContext)
    {
        this.dbContext = dbContext;

    }

    public List<Server> GetAllServers()
    {
        var allServers = dbContext.Servers.ToList();
        return allServers;
    }

    public Server? GetServerById(Guid id)
    {
        var server = dbContext.Servers.Find(id);
        return server;
    }

    public Server AddServer(AddServerDto dto)
    {
        var newServer = new Server
        {
            UserId = dto.UserId,
            StatusWorkerId = 1,
            MaxTables = dto.MaxTables ?? 5
        };
        dbContext.Servers.Add(newServer);
        dbContext.SaveChanges();

        return newServer;
    }

    public bool DeleteServer(Guid id)
    {
        var server = dbContext.Servers.Find(id);

        if (server is null)
        {
            return false;
        }

        dbContext.Servers.Remove(server);
        dbContext.SaveChanges();

        return true;
    }

    public bool UpdateServer(Guid id, UpdateServerDto dto)
    {
        var server = dbContext.Servers.Find(id);
        if (server is null)
        {
            return false;
        }

        if (dto.NewStatusWorkerId.HasValue)
        {
            server.StatusWorkerId = dto.NewStatusWorkerId.Value;
        }

        if (dto.NewMaxTables.HasValue)
        {
            server.MaxTables = dto.NewMaxTables.Value;
        }

        dbContext.SaveChanges();

        return true;
    }

}