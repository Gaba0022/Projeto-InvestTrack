using backend.Application.DTOs.User;

namespace backend.Application.DTOs;

public class AuthResponseDTO
{
    public string Token { get; set; }
    public ReadUserDTO User { get; set; }
}
