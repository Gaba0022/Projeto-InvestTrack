using AutoMapper;
using backend.Application.DTOs.User;
using backend.Domain.Entities;

namespace backend.Shared;

public class MappingProfile:Profile
{
    public MappingProfile() 
    {
        CreateMap<CreateUserDTO, User>();
        CreateMap<User, ReadUserDTO>();
        CreateMap<UpdateUserDTO, User>();
    }

}
