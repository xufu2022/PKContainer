namespace KP.SharedKernel;

public abstract class BaseEntity : IEntity
{
    public bool IsDeleted { get; set; }
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
    public string CreatedByName { get; set; } = "";
    public string ModifiedByName { get; set; } = "";
}