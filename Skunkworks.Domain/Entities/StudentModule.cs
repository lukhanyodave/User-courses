

using Skunkworks.Domain.Base;

namespace Skunkworks.Domain.Entities;

public  class StudentModule :BaseClass
{
   public string? Grade { get; set; } = string.Empty;
   public bool IsCompleted { get; set; } = false;
   
}
