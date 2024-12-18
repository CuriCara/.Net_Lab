using AutoMapper;
using BusinessLogic.Users.Manager;
using BusinessLogic.Users.Model;
using BusinessLogic.Users.Provider;
using Microsoft.AspNetCore.Mvc;
using Service.Controllers.Entity;
using Service.Validation;

namespace Service.Controllers;


[ApiController]
[Route("[controller]")]
public class UsersController :ControllerBase
{
    private readonly IUserManager _userManager;
    private readonly IUserProvider _userProvider;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    
    public UsersController(IUserManager userManager, IUserProvider userProvider, IMapper mapper, ILogger logger)
    {
        _userManager = userManager;
        _userProvider = userProvider;
        _mapper = mapper;
        _logger = logger;
    }
    
    [HttpPost]
    public IActionResult RegisterUser([FromBody] RegisterUserRequest request)
    {
        var validationResult = new RegisterUserRequestsValidator().Validate(request);
        if (validationResult.IsValid)
        {
            var createUserModel = _mapper.Map<CreateUserModel>(request);
            var userModel = _userManager.CreateUser(createUserModel);
            return Ok(new UserResponse()
            {
                Users = [userModel]
            });
        }
        _logger.LogError(validationResult.ToString());
        return BadRequest(validationResult.ToString());
    }
    
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _userProvider.GetUsers();
        return Ok(new UserResponse()
        {
            Users = users.ToList()
        });
    }

    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredUsers([FromBody] UserFilter filter)
    {
        var userFilterModel = _mapper.Map<UserFilterModel>(filter);
        var users = _userProvider.GetUsers(userFilterModel);
        return Ok(new UserResponse()
        {
            Users = users.ToList()
        });
    }
}