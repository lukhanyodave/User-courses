
namespace Skunkworks.Application.Features.Profiles.Command;

public class CreateProfileRequest
{
    public required Guid UserId { get; set; }
    public string? Address { get; set; } = string.Empty;
    public string? Contact { get; set; } = string.Empty;
    public string? CreatedBy { get; set; } = string.Empty;
}
