using FluentValidation;
using Ofernandoavila.Academy.Business.Models.AccessControl;
using Ofernandoavila.Academy.Business.Utils.Dictionary;
using Ofernandoavila.Academy.Business.Utils.Validation;

namespace Ofernandoavila.Academy.Business.Validations.AccessControl
{
    public class UserValidation : AbstractValidator<User>
    {
        public static string EmptyOrNullNameErrorMessage => "The field Name must be given.";
        public static string LengthNameErrorMessage => "The field Name must be between 3 and 100 characters.";
        public static string RegexNameErrorMessage => "The field Name must be valid.";

        public static string EmptyOrNullEmailErrorMsg => "The field E-mail must be a valid e-mail.";
        public static string LengthEmailErroMsg => "The field E-mail must be between 3 and 100 characters.";

        public static string EmptyOrNullRoleIdErrorMsg => "The field Role Id must be given.";
        public static string EnumRoleIdErroMsg => "The field Role Id must be a valid Role.";

        public UserValidation()
        {
            RuleFor(f => f.Name)
                .NotNull().WithMessage(EmptyOrNullNameErrorMessage)
                .NotEmpty().WithMessage(EmptyOrNullNameErrorMessage)
                .Length(3, 100).WithMessage(LengthNameErrorMessage)
                .Must(StringValidations.CheckIsValidName).WithMessage(RegexNameErrorMessage);

            RuleFor(f => f.Email)
               .EmailAddress().WithMessage(EmptyOrNullEmailErrorMsg)
               .Must(StringValidations.CheckIsValidMail).WithMessage(EmptyOrNullEmailErrorMsg)
               .Length(3, 100).WithMessage(LengthEmailErroMsg);

            RuleFor(f => f.RoleId)
                .NotNull().WithMessage(EmptyOrNullRoleIdErrorMsg)
                .NotEmpty().WithMessage(EmptyOrNullRoleIdErrorMsg)
                .Must(CheckDictionary.ValidateRole).WithMessage(EnumRoleIdErroMsg);
        }
    }

    public class UsuarioPasswordValidation : AbstractValidator<User>
    {
        public static string PasswordErroMsg => "The field Password must be between 6 and 20 characters and at least 1 upper case, 1 lower case, 1 number and 1 special character.";

        public UsuarioPasswordValidation()
        {
            RuleFor(f => f.Password)
                .Must(StringValidations.CheckStringForMinLengthLettersNumbersCharacters).WithMessage(PasswordErroMsg);
        }
    }
}
