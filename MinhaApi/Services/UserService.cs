using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using MinhaApi.Controllers;
using MinhaApi.Data;
using MinhaApi.DTO;
using MinhaApi.Models;

public class UserService : IUserService
{
    private readonly DishBoardProdContext dbContext;
    private readonly IServerService serverService;


    public UserService(DishBoardProdContext dbContext, IServerService serverService)
    {
        this.dbContext = dbContext;
        this.serverService = serverService;

    }

    public List<User> GetAllUsers()
    {
        var allUsers = dbContext.Users.ToList();

        return allUsers;
    }

    public User? GetUserById(Guid id)
    {
        var user = dbContext.Users.Find(id);

        return user;
    }

    public User AddUser(AddUserDto dto)
    {
        var newUser = new User()
        {
            Email = dto.Email,
            UserPassword = dto.UserPassword,
            Username = dto.Username,
            Role = dto.Role,
            PhoneNumber = dto.PhoneNumber,
            ProfileImage = dto.ProfileImage
        };

        dbContext.Users.Add(newUser);
        dbContext.SaveChanges();

        if (newUser.Role == "Server")
        {
            serverService.AddServer(new AddServerDto
            {
                UserId = newUser.Id
            });
        }

        
        
        return newUser;
    }

    public bool DeleteUser(Guid id)
    {
        var user = dbContext.Users.Find(id);

        if (user is null)
        {
            return false;
        }
        dbContext.Users.Remove(user);
        dbContext.SaveChanges();

        return true;
    }

    public bool UpdateUser(Guid id, UpdateUserDto dto)
    {
        var user = dbContext.Users.Find(id);
        if (user is null)
        {
            return false;
        }

        if (dto.NewEmail != null)
        {
            user.Email = dto.NewEmail;
        }

        if (dto.NewUserPassword != null)
        {
            user.UserPassword = dto.NewUserPassword;
        }

        if (dto.NewUsername != null)
        {
            user.Username = dto.NewUsername;
        }

        if (dto.NewRole != null)
        {
            user.Role = dto.NewRole;
        }

        if (dto.NewPhoneNumber != null)
        {
            user.PhoneNumber = dto.NewPhoneNumber;
        }

        if (dto.NewProfileImage != null)
        {
            user.ProfileImage = dto.NewProfileImage;
        }

        dbContext.SaveChanges();
        return true;
    }

}