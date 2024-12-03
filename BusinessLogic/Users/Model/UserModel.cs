namespace BusinessLogic.Users.Model;

public class UserModel
{
    public int Id { get; set; }
    
    public string UserName { get; set; }
    
    public string PasswordHash { get; set; }
    
    public int RoleId { get; set; }
    
    public string Email { get; set; }
    
    public DateTime CreationTime { get; set; }
    
    public DateTime ModificationTime { get; set; }
}