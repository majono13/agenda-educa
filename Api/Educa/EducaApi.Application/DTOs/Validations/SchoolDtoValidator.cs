using FluentValidation;
using System.Text.RegularExpressions;

namespace EducaApi.Application.DTOs.Validations
{
    public class SchoolDtoValidator : AbstractValidator<SchoolDTO>
    {
        public SchoolDtoValidator()
        {
            #region Name
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe o nome da escola!");

            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres!");

            RuleFor(x => x.Name)
                 .MaximumLength(100)
                 .WithMessage("O nome deve ter no máximo 100 caracteres!");

            #endregion

            #region Address
            RuleFor(x => x.Cep)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe o Cep!");

            //Cep
            RuleFor(x => x.Cep)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage("Informe o Cep!");

            RuleFor(x => x.Cep).Must((x => ValidateCep(x)))
                 .WithMessage("Cep inválido!");

            //City
            RuleFor(x => x.City)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage("Informe a Cidade!");


            RuleFor(x => x.City)
                .MinimumLength(3)
                .WithMessage("O nome da cidade deve ter no mínimo 3 caracteres!");

            RuleFor(x => x.City)
                 .MaximumLength(100)
                 .WithMessage("O nome da cidade deve ter no máximo 100 caracteres!");

            //Sreet
            RuleFor(x => x.Street)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage("Informe a rua!");

            RuleFor(x => x.Street)
                .MinimumLength(3)
                .WithMessage("O nome da rua deve ter no mínimo 3 caracteres!");

            RuleFor(x => x.Street)
                 .MaximumLength(100)
                 .WithMessage("O nome da rua deve ter no máximo 100 caracteres!");

            //District
            RuleFor(x => x.District)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage("Informe o bairro!");

            RuleFor(x => x.District)
                .MinimumLength(3)
                .WithMessage("O nome da rua deve ter no mínimo 3 caracteres!");

            RuleFor(x => x.District)
                 .MaximumLength(100)
                 .WithMessage("O nome da rua deve ter no máximo 100 caracteres!");

            //State
            RuleFor(x => x.State)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage("Informe o estado!");

            RuleFor(x => x.State)
                .MinimumLength(3)
                .WithMessage("O nome do estado deve ter no mínimo 3 caracteres!");

            RuleFor(x => x.State)
                 .MaximumLength(100)
                 .WithMessage("O nome do estado deve ter no máximo 100 caracteres!");

            //Number
            RuleFor(x => x.Number)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage("Informe o número!");

            RuleFor(x => x.Number)
                 .MaximumLength(10)
                 .WithMessage("O número deve ter no máximo 10 caracteres");

            #endregion
        }

        private static bool ValidateCep(string cep)
        {
            var regex = @"^\d{5}-\d{3}$";
            var math = Regex.Match(cep, regex);

            if (math.Success) return true;
            return false;
        } 
    }
}
