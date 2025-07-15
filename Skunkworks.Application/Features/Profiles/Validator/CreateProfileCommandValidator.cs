using Azure.Core;
using FluentValidation;
using Skunkworks.Application.Features.Profiles.Command;

namespace Skunkworks.Application.Features.Profiles.Validator
{
    public  class CreateProfileCommandValidator : AbstractValidator<CreateProfileCommand>
    {
        public CreateProfileCommandValidator()
        {
            RuleFor(c => c.request.UserId).NotEmpty();
            RuleFor(c => c.request.Address).NotEmpty();
            RuleFor(c => c.request.CreatedBy).NotEmpty().MaximumLength(255);
        }
    }
}
