using Application.Contracts.Request;
using FluentValidation;

namespace CliVetDogsCats.API.Validators
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(model => model.Code).NotEmpty()
                .WithMessage("O código do produto é obrigatório");

            RuleFor(model => model.Name).NotEmpty()
                   .WithMessage("O nome do produto é obrigatório");

            RuleFor(model => model.Description).NotEmpty()
                   .WithMessage("Uma descrição do produto é obrigatório");

            RuleFor(model => model.CostValue).NotEmpty()
                   .WithMessage("O valor de custo do produto é obrigatório");

            RuleFor(model => model.ProfitMargin).NotEmpty()
                   .WithMessage("Uma margem de lucro do produto é obrigatório");

            RuleFor(model => model.SaleValue).NotEmpty()
                   .WithMessage("O valor de venda do produto é obrigatório");

            RuleFor(model => model.StockQuantity).NotEmpty()
                   .WithMessage("Uma quantidade de estoque do produto é obrigatório");

            RuleFor(model => model.Category.Id).NotEmpty()
                   .WithMessage("Uma categoria do produto é obrigatório");

            RuleFor(model => model.Brand.Id).NotEmpty()
                   .WithMessage("Uma marca do produto é obrigatório");
        }
    }
}
