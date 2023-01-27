using EducaApi.Application.DTOs;
using FluentValidation;

namespace EducaApi.Application.Validations
{
    public class TeacherDtoValidator : AbstractValidator<TeacherDto>
    {
        public TeacherDtoValidator()
        {
            #region Nome
            RuleFor(X => X.Firstname)
             .NotEmpty()
             .NotNull()
             .WithMessage("Informe o primeiro nome");

            RuleFor(X => X.Firstname)
             .MinimumLength(3)
             .WithMessage("O nome deve ter no mínimo 3 caracteres");

            RuleFor(X => X.Firstname)
             .MaximumLength(20)
             .WithMessage("O nome deve ter no máximo 20 caracteres");
            #endregion

            #region Sobrenome
            RuleFor(X => X.Lastname)
             .NotEmpty()
             .NotNull()
             .WithMessage("Informe o sobrenome");

            RuleFor(X => X.Lastname)
             .MinimumLength(2)
             .WithMessage("O sobrenome deve ter no mínimo 2 caracteres");

            RuleFor(X => X.Lastname)
             .MaximumLength(100)
             .WithMessage("O sobrenome deve ter no máximo 50 caracteres");
            #endregion

            #region Telefone
            RuleFor(X => X.Phone)
             .NotEmpty()
             .NotNull()
             .WithMessage("Informe o telefone");

            RuleFor(X => X.Phone)
             .MinimumLength(11)
             .MaximumLength(11)
             .WithMessage("Número de telefone inválido");
            #endregion

        }
    }
}
