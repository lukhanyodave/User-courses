using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skunkworks.Application.Features.StudentRequests.Command
{
    public class UpdateStudentCourse
    {
        public required Guid UserId { get; set; }
        public string? Course { get; set; } = string.Empty;
        public string? UpdatedBy { get; set; } = string.Empty;
        public bool Approved { get; set; }
    }
}
