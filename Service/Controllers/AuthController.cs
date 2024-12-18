using BusinessLogic.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers;

public class AuthController(IAuthProvider _authProvider) : ControllerBase
{
    [HttpGet]
    [Route("logic")]
    public async Task<IActionResult> LoginUser([FromQuery] string email, [FromQuery] string password)
    {
        try
        {
            var authUser = await _authProvider.AuthorizeUser(email, password);
            return Ok(authUser);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterUser(string email, string password)
    {
        try
        {
            var newUser = await _authProvider.RegisterUser(email, password);
            return Ok(newUser);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}