namespace DataAccess.Entity;

public abstract class BaseEntity
{
    public int Id { get; set; }
    
    public DateTime CreationTime { get; set; }
    
    public DateTime ModificationTime { get; set; }

    public void init()
    {
        CreationTime = DateTime.UtcNow;
        ModificationTime = DateTime.UtcNow;
    }
}