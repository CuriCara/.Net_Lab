using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entity;

[Table("Role")]
public class Role
{
    public int Id { get; set; }
    
    public string RoleValue { get; set; }
    
    public List<User> Users { get; set; }
}