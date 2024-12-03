namespace BusinessLogic.Users.Manager;

using BusinessLogic.Users.Model;

public interface IUserManager
{
    UserModel CreateUser(CreateUserModel createUserModel);

    UserModel UpdateUser(UpdateUserModel updateUserModel);

    void DeleteUser(int id);
}