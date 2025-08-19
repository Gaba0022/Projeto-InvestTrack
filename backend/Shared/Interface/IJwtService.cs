using backend.Domain.Entities;

namespace backend.Shared.Interface;

public interface IJwtService
{
    string GenerateToken(User user);      
}
