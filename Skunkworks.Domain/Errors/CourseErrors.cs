

using Skunkworks.Shared;

namespace Skunkworks.Domain.Errors;

public static class CourseErrors
{
    public static Error AlreadyCompleted(Guid Id) => Error.Problem(
       "Course.AlreadyCompleted",
       $"The course with Id = '{Id}' is already completed.");

    public static Error NotFound(Guid Id) => Error.NotFound(
        "Course.NotFound",
        $"The course with the Id = '{Id}' was not found");
}
