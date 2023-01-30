using FluentValidation;

namespace EducaApi.Application.DTOs.Validations
{
    public class UserDtoValidator : AbstractValidator<UserDTO>
    {
        public UserDtoValidator()
        {

            #region Email
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe o e-mail!");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Formato de e-mail inválido!");
            #endregion

            #region Password
            RuleFor(x => x.Password)
                  .NotNull()
                  .NotEmpty()
                 .WithMessage("Informe a senha!");

            RuleFor(x => x.Password)
                .MinimumLength(6)
                .WithMessage("A senha deve ter no mínimo 6 caracteres");

            RuleFor(x => x.Password)
                .MaximumLength(20)
                .WithMessage("A senha deve ter no máximo 20 caracteres");
            #endregion
        }
    }
}
