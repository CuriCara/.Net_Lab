using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entity;

[Table("UnitsOfMeasurement")]
public class UnitsOfMeasurement
{
    public int Id { get; set; }
    
    public string UoM { get; set; }
    
    public List<Product> Products { get; set; }
}