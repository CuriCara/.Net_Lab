using BusinessLogic.Authorization.Entity;
using BusinessLogic.Users.Model;

namespace BusinessLogic.Authorization;

public interface IAuthProvider
{
    Task<UserModel> RegisterUser(string email, string password);
    Task<TokensResponse> AuthorizeUser(string email, string password);
}