using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entity;

[Table("Product")]
public class Product : BaseEntity
{
    public string ProductName { get; set; }
    
    public int UoMId { get; set; }
    
    [ForeignKey("UoMId")]
    public UnitsOfMeasurement UnitsOfMeasurement { get; set; }
    
    public List<Harvest> Harvests { get; set; }
}