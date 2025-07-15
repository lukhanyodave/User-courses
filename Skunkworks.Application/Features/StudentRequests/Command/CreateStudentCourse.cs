

namespace Skunkworks.Application.Features.StudentRequests.Command
{
    public class CreateStudentCourse
    {
        public required Guid UserId { get; set; }
        public string? Course { get; set; } = string.Empty;
        public string? CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public bool Approved { get; set; }
    }
}
