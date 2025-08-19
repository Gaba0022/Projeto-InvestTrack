using backend.Domain.Entities;

namespace backend.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);                    // Cria um novo usuário
    Task<User?> GetByIdAsync(int id);                     // Busca por ID
    Task<User?> GetByEmailAsync(string email);            // Busca por email
    Task<User> UpdateAsync(User user);                    // Atualiza o usuário
    Task DeleteAsync(int id);                             // Deletar usuário
}
