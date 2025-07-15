using Skunkworks.Domain.Base;


namespace Skunkworks.Domain.Entities;

public  class Module:BaseClass
{
 
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public int SequenceNumber { get; set; }   
}
