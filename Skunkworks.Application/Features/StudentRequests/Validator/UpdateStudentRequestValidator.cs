using FluentValidation;
using Skunkworks.Application.Features.StudentRequests.Command;
namespace Skunkworks.Application.Features.StudentRequests.Validator
{
    public class UpdateStudentRequestValidator : AbstractValidator<UpdateStudentCourseRequestCommand>
    {
        public UpdateStudentRequestValidator()
        {
            RuleFor(c => c.command.UserId).NotEmpty();
            RuleFor(c => c.command.Course).NotEmpty();
            RuleFor(c => c.command.UpdatedBy).NotEmpty().MaximumLength(255);
        }
    }

}
