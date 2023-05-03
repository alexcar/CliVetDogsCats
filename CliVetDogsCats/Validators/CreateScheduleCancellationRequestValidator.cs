using Application.Contracts.Request;
using FluentValidation;

namespace CliVetDogsCats.API.Validators
{
    public class CreateScheduleCancellationRequestValidator : AbstractValidator<ScheduleCancellationRequest>
    {
        public CreateScheduleCancellationRequestValidator()
        {
            RuleFor(model => model.ScheduleId).NotEmpty()
                .WithMessage("É obrigatório informar um agendamento");

            RuleFor(model => model.ScheduleStatusId).NotEmpty()
                .WithMessage("É obrigatório selecionar um status para o agendamento");

            RuleFor(model => model.ScheduleComments).NotEmpty()
                .WithMessage("Um comentário para o cancelamento do agendamento é obrigatório");
        }
    }
}
