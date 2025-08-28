namespace MinhaApi.DTO
{
    public class AddUserDto
    {
    public string Email { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? ProfileImage { get; set; }
    }

}


