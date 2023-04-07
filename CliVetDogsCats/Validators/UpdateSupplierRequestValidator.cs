using Application.Contracts.Request;
using FluentValidation;

namespace CliVetDogsCats.API.Validators
{
    public class UpdateSupplierRequestValidator : AbstractValidator<UpdateSupplierRequest>
    {
        public UpdateSupplierRequestValidator()
        {
            RuleFor(model => model.Id).Must(ValidateGuid.BeAValidGuid).WithMessage("O ID do fornecedor é obrigatório");

            RuleFor(model => model.Name).NotEmpty()
                .WithMessage("O nome do fornecedor é obrigatório");

            RuleFor(model => model.Trade).NotEmpty()
                .WithMessage("O nome fantasia do fornecedor é obrigatório");

            RuleFor(model => model.Contact).NotEmpty()
                .WithMessage("O nome do contato do fornecedor é obrigatório");

            RuleFor(model => model.Email)
                .NotEmpty().WithMessage("O email do fornecedor é obrigatório")
                .MaximumLength(100).WithMessage("O email não pode ultrapassar a 100 caracteres")
                .EmailAddress().WithMessage("O email informado não tem um formato válido");

            RuleFor(model => model.Cnpj).NotEmpty()
                .WithMessage("O número do CNPJ do fornecedor é obrigatório");

            RuleFor(model => model.Phone).NotEmpty()
                .WithMessage("O número do telefone do fornecedor é obrigatório");

            RuleFor(model => model.CellPhone).NotEmpty()
                .WithMessage("O número do celular do fornecedor é obrigatório");

            RuleFor(model => model.Address).SetValidator(new UpdateAddressRequestValidator());
        }
    }
}
