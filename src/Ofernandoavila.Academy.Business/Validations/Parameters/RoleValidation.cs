using FluentValidation;
using Ofernandoavila.Academy.Business.Models.Parameters;

namespace Ofernandoavila.Academy.Business.Validations.Parameters
{
    public class RoleValidation : AbstractValidator<Role>
    {
        private const int MaxDescriptionLength = 50;
        private readonly static string EmptyOrNullDescriptionErrorMessage = "The field Description must be given.";
        private readonly static string LengthDescriptionErrorMessage = $"The field Description must have {MaxDescriptionLength} characters at maximum";

        public RoleValidation()
        {
            RuleFor(t => t.Description)
                .NotNull().WithMessage(EmptyOrNullDescriptionErrorMessage)
                .NotEmpty().WithMessage(EmptyOrNullDescriptionErrorMessage)
                .MaximumLength(MaxDescriptionLength).WithMessage(LengthDescriptionErrorMessage);
        }
    }
}
