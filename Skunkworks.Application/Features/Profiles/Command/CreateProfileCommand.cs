

using Skunkworks.Application.Abstractions.Messaging;

namespace Skunkworks.Application.Features.Profiles.Command;

public sealed record CreateProfileCommand(CreateProfileRequest request) :ICommand<Guid>;
