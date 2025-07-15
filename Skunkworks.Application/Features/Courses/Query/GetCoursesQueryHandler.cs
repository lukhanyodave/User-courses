using Microsoft.EntityFrameworkCore;
using Skunkworks.Application.Abstractions.Messaging;
using Skunkworks.Infrastructure.Database;
using Skunkworks.Shared;

namespace Skunkworks.Application.Features.Courses.Query;

public sealed record GetCoursesQuery() : IQuery<List<CourseResponse>>;
internal sealed class GetCoursesQueryHandler(DemoDbContext context) : IQueryHandler<GetCoursesQuery, List<CourseResponse>>
{
    public async Task<Result<List<CourseResponse>>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {

        List<CourseResponse> courseResponses = await context.Courses
           .Select(course => new CourseResponse
           {
               Id = course.Id,
               Name = course.CourseName,
               PreRequisites = course.PreRequisites
           })
           .ToListAsync(cancellationToken);
        return courseResponses;
    }
}
