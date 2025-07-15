using Microsoft.EntityFrameworkCore;
using SharedKernel;
using Skunkworks.Application.Abstractions.Messaging;
using Skunkworks.Application.Features.Users;
using Skunkworks.Domain.Entities;
using Skunkworks.Domain.Errors;
using Skunkworks.Infrastructure.Database;
using Skunkworks.Shared;

namespace Skunkworks.Application.Features.StudentRequests.Command;

public class UpdateStudentCourseRequestCommandHandler(DemoDbContext context)  : ICommandHandler<UpdateStudentCourseRequestCommand>
{ 
    public async  Task<Result> Handle(UpdateStudentCourseRequestCommand command, CancellationToken cancellationToken)
    {
        StudentRequest? studentRequest = await context.StudentRequests.AsNoTracking()
           .SingleOrDefaultAsync(u => u.Id == command.command.UserId, cancellationToken);

        if (studentRequest is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound(command.command.UserId));
        }

        if (studentRequest.Approved)
        {
            return Result.Failure(StudentRequestErrors.AlreadyApproved(command.command.UserId));
        }

        studentRequest.Approved = true;
        studentRequest.UpdatedDate = DateTime.UtcNow;
        studentRequest.UpdateBy = command.command.UpdatedBy ?? command.command.UserId.ToString();
        await context.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}

