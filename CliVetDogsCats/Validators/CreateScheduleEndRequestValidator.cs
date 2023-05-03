using Application.Contracts.Request;
using FluentValidation;

namespace CliVetDogsCats.API.Validators
{
    public class CreateScheduleEndRequestValidator : AbstractValidator<ScheduleEndRequest>
    {
        public CreateScheduleEndRequestValidator()
        {
            RuleFor(model => model.ScheduleId).NotEmpty()
                .WithMessage("É obrigatório informar um agendamento");

            RuleFor(model => model.ScheduleStatusId).NotEmpty()
                .WithMessage("É obrigatório selecionar um status para o agendamento");
        }
    }
}
