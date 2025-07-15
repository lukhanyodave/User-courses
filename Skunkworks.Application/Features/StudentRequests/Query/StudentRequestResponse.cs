namespace Skunkworks.Application.Features.StudentRequests.Query;

public class StudentRequestResponse
{
    public Guid StudentRequestResponseId { get; set; }
    public Guid UserId { get; set; }
    public required string Course { get; set; } = string.Empty;
    public bool Approved { get; set; } = false;
    public DateTime CreatedDate { get; set; }
}
