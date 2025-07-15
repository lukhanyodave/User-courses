using Skunkworks.Application.Abstractions.Messaging;
namespace Skunkworks.Application.Features.Profiles.Command;

public sealed record UpdateProfileCommand(UpdateProfileRequest request) :ICommand;
