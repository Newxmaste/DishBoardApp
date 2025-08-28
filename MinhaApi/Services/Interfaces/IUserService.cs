using MinhaApi.Models;
using MinhaApi.DTO;
public interface IUserService
{
    List<User> GetAllUsers();
    User? GetUserById(Guid id);
    User AddUser(AddUserDto dto);
    bool UpdateUser(Guid id, UpdateUserDto dto);
    bool DeleteUser(Guid id);
}