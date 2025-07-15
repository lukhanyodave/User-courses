

using Skunkworks.Domain.Base;

namespace Skunkworks.Domain.Entities;

public  class StudentRequest:BaseClass
{
    public Guid StudentId { get; set; }
    public required string  Course { get; set; } = string.Empty; 
    public bool Approved { get; set; } = false;
}
