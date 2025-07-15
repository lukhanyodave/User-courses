using Microsoft.EntityFrameworkCore;
using Skunkworks.Application.Abstractions.Messaging;
using Skunkworks.Domain.Entities;
using Skunkworks.Domain.Errors;
using Skunkworks.Infrastructure.Database;
using Skunkworks.Shared;

namespace Skunkworks.Application.Features.Profiles.Command;

internal sealed class UpdateProfileCommandHandler(DemoDbContext context) : ICommandHandler<UpdateProfileCommand>
{
    public async  Task<Result> Handle(UpdateProfileCommand command, CancellationToken cancellationToken)
    {
        Profile? profile = await context.Profiles
           .SingleOrDefaultAsync(t => t.Id == command.request.UserId , cancellationToken);

        if (profile is null)
        {
            return Result.Failure(ProfileErros.NotFound(command.request.UserId));
        }

        profile.Contact = command.request.Contact;  
        profile.Address = command.request.Address;
        profile.UpdateBy = command.request.UpdatedBy ?? command.request.UserId.ToString();
        profile.UpdatedDate = DateTime.UtcNow;
        await context.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
