

namespace Skunkworks.Domain.Base;

public abstract class BaseClass
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CreatedBy { get; set; } = string.Empty;
    public string UpdateBy { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } 
    public DateTime UpdatedDate { get; set; } 
}
