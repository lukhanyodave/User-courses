

using Skunkworks.Domain.Base;

namespace Skunkworks.Domain.Entities;

public class Course : BaseClass
{
    public string CourseName { get; set; } = string.Empty;
    public string PreRequisites { get;  set; } = string.Empty;

    public List<Guid> Modules { get; set; } = new List<Guid>();
}
