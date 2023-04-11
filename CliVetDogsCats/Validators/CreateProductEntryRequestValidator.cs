using Application.Contracts.Request;
using FluentValidation;

namespace CliVetDogsCats.API.Validators
{
    public class CreateProductEntryRequestValidator : AbstractValidator<CreateProductEntryRequest>
    {
        public CreateProductEntryRequestValidator()
        {
            RuleFor(model => model.CostValue).NotEmpty()
                .WithMessage("O valor de custo do produto é obrigatório");

            RuleFor(model => model.Quantity).NotEmpty()
                .WithMessage("A quantidade do produto é obrigatório");
        }
    }
}
