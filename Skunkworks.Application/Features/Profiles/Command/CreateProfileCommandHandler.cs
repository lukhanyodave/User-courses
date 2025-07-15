using Microsoft.EntityFrameworkCore;
using SharedKernel;
using Skunkworks.Application.Abstractions.Messaging;
using Skunkworks.Application.Features.Users;
using Skunkworks.Domain.Entities;
using Skunkworks.Infrastructure.Database;
using Skunkworks.Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Skunkworks.Application.Features.Profiles.Command;

internal sealed class CreateProfileCommandHandler(DemoDbContext context) : ICommandHandler<CreateProfileCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateProfileCommand command, CancellationToken cancellationToken)
    {
      

        User? user = await context.Users.AsNoTracking()
            .SingleOrDefaultAsync(u => u.Id == command.request.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound(command.request.UserId));
        }

        var profile = new Profile
        {
            UserId = command.request.UserId,
            Address = command.request.Address,
            Contact = command.request.Contact,
            //CreatedBy = command.CreatedBy,
            CreatedDate = DateTime.UtcNow
        };

      

        context.Profiles.Add(profile);

        await context.SaveChangesAsync(cancellationToken);

        return profile.Id;
    }
}
