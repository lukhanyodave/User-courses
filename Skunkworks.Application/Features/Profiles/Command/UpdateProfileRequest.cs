namespace Skunkworks.Application.Features.Profiles.Command;

public class UpdateProfileRequest
{
    public required Guid UserId { get; set; }
    public string? Address { get; set; } = string.Empty;
    public string? Contact { get; set; } = string.Empty;
    public string? UpdatedBy { get; set; } = string.Empty;
    public DateTime? UpdatedDate { get; set; }
}
