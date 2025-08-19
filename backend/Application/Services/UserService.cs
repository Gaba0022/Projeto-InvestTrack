using AutoMapper;
using backend.Application.DTOs;
using backend.Application.DTOs.User;
using backend.Domain.Entities;
using backend.Infrastructure.Repositories;
using backend.Shared.Interface;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity;


namespace backend.Application.Services;

public class UserService
{
    private readonly UserRepository _repository;
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;

    public UserService(UserRepository repository, IMapper mapper, IJwtService jwtService)
    {
        _repository = repository;
        _mapper = mapper;
        _jwtService = jwtService;
    }

    public async Task<AuthResponseDTO> RegisterAsync(CreateUserDTO dto)
    {
        var user = _mapper.Map<User>(dto);
        user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var createdUser = await _repository.CreateAsync(user);
        var token = _jwtService.GenerateToken(createdUser);
        var readUserDto = _mapper.Map<ReadUserDTO>(createdUser);

        return new AuthResponseDTO { User = readUserDto, Token = token };
    }

    public async Task<AuthResponseDTO> LoginAsync(LoginUserDTO dto)
    {
        var user = await _repository.GetByEmailAsync(dto.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            throw new Exception("Credenciais inválidas");

        var token = _jwtService.GenerateToken(user);
        var readUserDto = _mapper.Map<ReadUserDTO>(user);
        return new AuthResponseDTO { User = readUserDto, Token = token };
    }
}
