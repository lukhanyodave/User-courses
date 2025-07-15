

using Skunkworks.Domain.Base;

namespace Skunkworks.Domain.Entities;

public  class Profile :BaseClass
{
    public required  Guid UserId { get; set; }
    public string? Address { get; set; } = string.Empty;
    public string? Contact { get; set; } = string.Empty;
}
