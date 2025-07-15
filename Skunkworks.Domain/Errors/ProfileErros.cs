using Skunkworks.Shared;
namespace Skunkworks.Domain.Errors
{
    public static  class ProfileErros
    {
        public static Error NotFound(Guid userId) => Error.NotFound(
        "Users.NotFound",
        $"The user with the Id = '{userId}' was not found");
    }
}
