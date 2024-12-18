using BusinessLogic.Users.Model;

namespace BusinessLogic.Users.Provider;

public interface IUserProvider
{
    IEnumerable<UserModel> GetUsers(UserFilterModel filter = null);
    UserModel GetInfo(int id);
}