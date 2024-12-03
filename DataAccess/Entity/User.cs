using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entity;

[Table("users")]
public class User : BaseEntity
{
    public string UserName { get; set; }
    
    public string PasswordHash { get; set; }
    
    public string Email { get; set; }
    
    public int RoleId { get; set; }
    
    [ForeignKey("RoleId")]
    public Role Role { get; set; }
    
    public List<Harvest> Harvests { get; set; }
    
    public List<UserRating> UserRatings { get; set; }
}