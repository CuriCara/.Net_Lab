using AutoMapper;
using BusinessLogic.Users.Model;
using Service.Controllers.Entity;

namespace Service.Mapper;

public class UsersServiceProfile : Profile
{
    public UsersServiceProfile()
    {
        CreateMap<UserFilter, UserFilterModel>();
        CreateMap<RegisterUserRequest, CreateUserModel>();
    }
}