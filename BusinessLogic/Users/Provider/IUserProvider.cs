using BusinessLogic.Users.Model;

namespace BusinessLogic.Users.Provider;

public interface IUserProvider
{
    IEnumerable<UserModel> GetUsers();
    UserModel GetInfo(int id);
}