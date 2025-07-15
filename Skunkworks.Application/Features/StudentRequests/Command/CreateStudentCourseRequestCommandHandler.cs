using Microsoft.EntityFrameworkCore;
using Skunkworks.Application.Abstractions.Messaging;
using Skunkworks.Application.Features.Profiles.Command;
using Skunkworks.Application.Features.Users;
using Skunkworks.Domain.Entities;
using Skunkworks.Infrastructure.Database;
using Skunkworks.Shared;
namespace Skunkworks.Application.Features.StudentRequests.Command;

internal sealed class CreateStudentCourseRequestCommandHandler(DemoDbContext context) : ICommandHandler<CreateStudentCourseRequestCommand, Guid>
{
    public async  Task<Result<Guid>> Handle(CreateStudentCourseRequestCommand request, CancellationToken cancellationToken)
    {
        StudentRequest? studentRequest = await context.StudentRequests.AsNoTracking()
            .SingleOrDefaultAsync(u => u.Id == request.command.UserId, cancellationToken);

        if (studentRequest is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound(request.command.UserId));
        }
        
            var srequest = new StudentRequest
            {
                StudentId = request.command.UserId,
                Course = request.command.Course ?? " ",
                Approved = false,
                CreatedBy = request.command.CreatedBy ?? "",
                CreatedDate = request.command.CreatedDate,

            };
            context.StudentRequests.Add(srequest);
            await context.SaveChangesAsync(cancellationToken);
            return srequest.Id;
        
    }
}
