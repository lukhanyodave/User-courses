using Microsoft.EntityFrameworkCore;
using Skunkworks.Application.Abstractions.Messaging;
using Skunkworks.Domain.Errors;
using Skunkworks.Infrastructure.Database;
using Skunkworks.Shared;

namespace Skunkworks.Application.Features.StudentRequests.Query;

public sealed  record  GetStudentCourseRequestQuery(Guid id): IQuery<StudentRequestResponse>;
internal sealed class GetStudentCourseRequestQueryHandler(DemoDbContext context) : IQueryHandler<GetStudentCourseRequestQuery, StudentRequestResponse>
{
    public async  Task<Result<StudentRequestResponse>> Handle(GetStudentCourseRequestQuery command, CancellationToken cancellationToken)
    {
        
            StudentRequestResponse? request = await context.StudentRequests
               // .Where(r => r.Approved == false)
                .Select(r => new StudentRequestResponse
                {
                    UserId = r.Id,
                    Course = r.Course,
                    Approved = r.Approved,
                    CreatedDate = r.CreatedDate
                })
                .SingleOrDefaultAsync(cancellationToken);
        if (request is null)
        {
            return Result.Failure<StudentRequestResponse>(StudentRequestErrors.NotFound(command.id));
        }
        return request;
    }
}
