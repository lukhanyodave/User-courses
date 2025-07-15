using Skunkworks.Application.Abstractions.Messaging;

namespace Skunkworks.Application.Features.StudentRequests.Command
{
    public sealed record UpdateStudentCourseRequestCommand(UpdateStudentCourse command) : ICommand;
    
}
