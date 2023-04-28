using Application.Contracts.Request;
using FluentValidation;

namespace CliVetDogsCats.API.Validators
{
    public class CreateTutorRequestValidator : AbstractValidator<CreateTutorRequest>
    {
        public CreateTutorRequestValidator()
        {
            RuleFor(model => model.Name).NotEmpty()
                .WithMessage("O nome do tutor é obrigatório");

            RuleFor(model => model.Cpf).NotEmpty()
                .WithMessage("O CPF do tutor é obrigatório");

            RuleFor(model => model.Rg).NotEmpty()
                .WithMessage("O RG do tutor é obrigatório");

            RuleFor(model => model.Email)
                .NotEmpty().WithMessage("O email do tutor é obrigatório")
                .MaximumLength(100).WithMessage("O email não pode ultrapassar a 100 caracteres")
                .EmailAddress().WithMessage("O email informado não tem um formato válido");

            RuleFor(model => model.CellPhone).NotEmpty()
                .WithMessage("O celular do tutor é obrigatório");
        }
    }
}
