using AutoMapper;
using BusinessLogic.Users.Exception;
using BusinessLogic.Users.Model;
using DataAccess.Repository;
using DataAccess.Entity;

namespace BusinessLogic.Users.Provider;

public class UserProvider : IUserProvider
{
    private readonly IRepository<User> _uRepository;
    private readonly IMapper _mapper;

    public UserProvider(IRepository<User> uRepository, IMapper mapper)
    {
        _uRepository = uRepository;
        _mapper = mapper;
    }

    public IEnumerable<UserModel> GetUsers()
    {
        var users = _uRepository.GetAll();
        if (users == null || !users.Any())
        {
            throw new UserNotFoundException("Not found!");
        }

        return _mapper.Map<IEnumerable<UserModel>>(users);
    }

    public UserModel GetInfo(int id)
    {
        var user = _uRepository.GetById(id);
        if (user == null)
        {
            throw new UserNotFoundException("Not found!");
        }

        return _mapper.Map<UserModel>(user);
    }
}