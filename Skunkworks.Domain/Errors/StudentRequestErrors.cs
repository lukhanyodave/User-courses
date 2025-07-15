using Skunkworks.Shared;

namespace Skunkworks.Domain.Errors;

public static class StudentRequestErrors
{
    public static Error AlreadyApproved(Guid id) => Error.Problem(
       "StudentRequest.AlreadyApproved",
       $"The request item with Id = '{id}' is already approved.");

    public static Error NotFound(Guid id) => Error.NotFound(
        "StudentRequest.NotFound",
        $"The request with the Id = '{id}' was not found");
}
