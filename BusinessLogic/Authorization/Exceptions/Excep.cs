using System.ComponentModel;

namespace BusinessLogic.Authorization.Exceptions;

public enum Excep
{
    [Description("Пользователь не найден!")] 
    UserNotFound = 001,
    
    [Description("Ошибка идентификации сервера!")]
    IdentityServerError = 002,

    [Description("Неверный логин или пароль!")]
    IncorrectPassOrEm = 003,

    [Description("Пользователь уже существует!")]
    UserAlreadyExists = 004,

    [Description("Ошибка создания пользователя!")]
    UserCreationError = 005,
}