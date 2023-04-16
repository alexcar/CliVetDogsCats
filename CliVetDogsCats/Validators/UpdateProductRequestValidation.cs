using Application.Contracts.Request;
using FluentValidation;

namespace CliVetDogsCats.API.Validators
{
    public class UpdateProductRequestValidation : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidation()
        {
            RuleFor(model => model.Id).Must(ValidateGuid.BeAValidGuid).WithMessage("O ID do empregado é obrigatório");

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

            RuleFor(model => model.CategoryId).NotEmpty()
                   .WithMessage("Uma categoria do produto é obrigatório");

            RuleFor(model => model.BrandId).NotEmpty()
                   .WithMessage("Uma marca do produto é obrigatório");
        }
    }
}
