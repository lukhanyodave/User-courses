using Skunkworks.Application.Abstractions.Messaging;
namespace Skunkworks.Application.Features.StudentRequests.Command;

public  record CreateStudentCourseRequestCommand(CreateStudentCourse command) : ICommand<Guid>;