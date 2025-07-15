using FluentValidation;
using Skunkworks.Application.Features.Profiles.Command;
using Skunkworks.Application.Features.StudentRequests.Command;

namespace Skunkworks.Application.Features.StudentRequests.Validator;

public class CreateStudentRequestValidator : AbstractValidator<CreateStudentCourseRequestCommand>
{
    public CreateStudentRequestValidator()
    {
        RuleFor(c => c.command.UserId).NotEmpty();
        RuleFor(c => c.command.Course).NotEmpty();
        RuleFor(c => c.command.CreatedBy).NotEmpty().MaximumLength(255);
    }
}
