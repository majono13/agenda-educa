using FluentValidation;
using EducaApi.Application.DTOs;

namespace EducaApi.Application.DTOs.Validations
{
    public class StudentDtoValidator : AbstractValidator<StudentDTO>
    {
        public StudentDtoValidator()
        {
            #region Name
            RuleFor(X => X.Name)
             .NotEmpty()
             .NotNull()
             .WithMessage("Informe o nome do aluno");

            RuleFor(X => X.Name)
             .MinimumLength(3)
             .WithMessage("O nome deve ter no mínimo 3 caracteres");

            RuleFor(X => X.Name)
               .MaximumLength(50)
               .WithMessage("O nome deve ter no máximo 50 caracteres");
            #endregion

            #region School
            RuleFor(X => X.School)
           .NotEmpty()
           .NotNull()
           .WithMessage("Informe a escola do aluno");

            RuleFor(X => X.School)
             .MinimumLength(3)
             .WithMessage("O nome da escola deve ter no mínimo 3 caracteres");

            RuleFor(X => X.School)
               .MaximumLength(50)
               .WithMessage("O nome da escola  deve ter no máximo 50 caracteres");
            #endregion

            #region Class
            RuleFor(X => X.Class)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe a classe do aluno");

            RuleFor(X => X.Class)
               .MaximumLength(15)
               .WithMessage("O nome deve ter no máximo 15 caracteres");
            #endregion
        }
    }
}
