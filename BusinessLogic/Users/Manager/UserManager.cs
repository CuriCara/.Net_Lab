using AutoMapper;
using BusinessLogic.Users.Exception;
using BusinessLogic.Users.Model;
using DataAccess.Repository;
using DataAccess.Entity;


namespace BusinessLogic.Users.Manager;

public class UserManager : IUserManager
{
    private readonly IRepository<User> _uRepository;
    private readonly IMapper _mapper;

    public UserManager(IRepository<User> uRepository, IMapper mapper)
    {
        _uRepository = uRepository;
        _mapper = mapper;
    }

    public UserModel CreateUser(CreateUserModel createUserModel)
    {
        var user = _mapper.Map<User>(createUserModel);
        user = _uRepository.Save(user);
        return _mapper.Map<UserModel>(user);
    }

    public UserModel UpdateUser(UpdateUserModel updateUserModel)
    {
        var user = _mapper.Map<User>(updateUserModel);
        user = _uRepository.Save(user);
        return _mapper.Map<UserModel>(user);
    }

    public void DeleteUser(int id)
    {
        var user = _uRepository.GetById(id);
        if (user == null)
        {
            throw new UserNotFoundException("Not found!");
        }
        _uRepository.Delete(user);
    }
}