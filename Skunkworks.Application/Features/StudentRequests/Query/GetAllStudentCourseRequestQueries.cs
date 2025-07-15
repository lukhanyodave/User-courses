using Microsoft.EntityFrameworkCore;
using Skunkworks.Application.Abstractions.Messaging;
using Skunkworks.Application.Features.Users;
using Skunkworks.Domain.Entities;
using Skunkworks.Infrastructure.Database;
using Skunkworks.Shared;
namespace Skunkworks.Application.Features.StudentRequests.Query;

public sealed  record GetAllStudentCourseRequestQueries(Guid id) :IQuery<List<StudentRequestResponse>>;
internal sealed class GetAllStudentCourseRequestQueriesHandler(DemoDbContext context) : IQueryHandler<GetAllStudentCourseRequestQueries, List<StudentRequestResponse>>
{
    public async  Task<Result<List<StudentRequestResponse>>> Handle(GetAllStudentCourseRequestQueries query, CancellationToken cancellationToken)
    {
        var user = await context.Users.FindAsync(query.id, cancellationToken);
        if(user is not null)
        {
            if (!user.IsTeacher)
            {
                return Result.Failure<List<StudentRequestResponse>>(UserErrors.Unauthorized());
            }

            List<StudentRequestResponse> request = await context.StudentRequests
                .Where(r => r.Approved == false)
                .Select(r => new StudentRequestResponse
                {
                    UserId = r.Id,
                    Course = r.Course,
                    Approved = r.Approved,
                    CreatedDate = r.CreatedDate
                })
                .ToListAsync(cancellationToken);

            return request;
        }
        else
            return Result.Failure<List<StudentRequestResponse>>(UserErrors.Unauthorized());
    }
}

