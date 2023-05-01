using Application.Contracts.Request;
using FluentValidation;

namespace CliVetDogsCats.API.Validators
{
    public class GetVetByDutyDateRequestValidator : AbstractValidator<GetVetByDutyDateRequest>
    {
        public GetVetByDutyDateRequestValidator()
        {
            RuleFor(model => model.dutyDate).NotEmpty().WithMessage("A data para a consulta é obrigatória");
            RuleFor(model => model.hour).NotEmpty().WithMessage("A hora para a consulta é obrigatória");
        }
    }
}
