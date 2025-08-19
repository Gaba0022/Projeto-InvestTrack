using System.ComponentModel.DataAnnotations;

namespace backend.Application.DTOs.User;

public class CreateUserDTO
{

    [Required]
    public string Name { get; private set; }

    [Required]
    public string Email { get; private set; }

    [Required]
    public string Password { get; private set; }

}
