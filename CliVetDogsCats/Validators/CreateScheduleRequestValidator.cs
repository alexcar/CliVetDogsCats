using Application.Contracts.Request;
using FluentValidation;

namespace CliVetDogsCats.API.Validators
{
    public class CreateScheduleRequestValidator : AbstractValidator<CreateScheduleRequest>
    {
        public CreateScheduleRequestValidator()
        {
            RuleFor(model => model.ScheduleDate).NotEmpty()
                .WithMessage("A data do agendamento é obrigatório");
            
            RuleFor(model => model.Hour).NotEmpty()
                .WithMessage("A hora do agendamento é obrigatório");

            RuleFor(model => model.ScheduleStatusId).NotEmpty()
                .WithMessage("É obrigatório selecionar um status para o agendamento");

            RuleFor(model => model.EmployeeId).NotEmpty()
                .WithMessage("o empregado que está realizando o agendamento é obrigatório");

            RuleFor(model => model.TutorId).NotEmpty()
                .WithMessage("É obrigatório selecionar um tutor para o agendamento");

            RuleFor(model => model.AnimalId).NotEmpty()
                .WithMessage("É obrigatório selecionar um animal para o agendamento");
        }
    }
}
