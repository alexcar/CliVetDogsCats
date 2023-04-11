using Application.Contracts.Request;
using FluentValidation;

namespace CliVetDogsCats.API.Validators
{
    public class CreateProductEntryHeaderRequestValidator : AbstractValidator<CreateProductEntryHeaderRequest>
    {
        public CreateProductEntryHeaderRequestValidator()
        {
            RuleFor(model => model.Code).NotEmpty()
                .WithMessage("O código do produto é obrigatório");

            RuleFor(model => model.EmployeeId).NotEmpty()
                .WithMessage("O código do empregado é obrigatório");

            RuleFor(model => model.SupplierId).NotEmpty()
                .WithMessage("O código do fornecedor é obrigatório");

            RuleForEach(model => model.ProductsEntry).SetValidator(new CreateProductEntryRequestValidator());             
        }
    }
}
