using Microsoft.EntityFrameworkCore;
using Skunkworks.Application.Abstractions.Messaging;
using Skunkworks.Domain.Errors;
using Skunkworks.Infrastructure.Database;
using Skunkworks.Shared;

namespace Skunkworks.Application.Features.Courses.Query;
public sealed record GetCourseByIdQuery(Guid Id) : IQuery<CourseResponse>;
internal class GetCourseByIdQueryHandler(DemoDbContext context)
     : IQueryHandler<GetCourseByIdQuery, CourseResponse>
{
    public async  Task<Result<CourseResponse>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        CourseResponse? course = await context.Courses
            .Where(c => c.Id == request.Id )
            .Select(c => new CourseResponse
            {
                Id = c.Id,
                Name = c.CourseName,
                PreRequisites = c.PreRequisites
            })
            .SingleOrDefaultAsync(cancellationToken);

        if (course is null)
        {
            return Result.Failure<CourseResponse>(CourseErrors.NotFound(request.Id));
        }

        return course;
    }
}
