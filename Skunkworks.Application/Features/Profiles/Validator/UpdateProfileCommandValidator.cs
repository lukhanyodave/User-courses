using FluentValidation;
using Skunkworks.Application.Features.Profiles.Command;

namespace Skunkworks.Application.Features.Profiles.Validator;

public  class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
{
    public UpdateProfileCommandValidator()
    {
        RuleFor(c => c.request.UserId).NotEmpty();
        RuleFor(c => c.request.Address).NotEmpty();
        RuleFor(c => c.request.Contact).NotEmpty().MaximumLength(255);
        RuleFor(c => c.request.UpdatedBy).NotEmpty();
    }
}
