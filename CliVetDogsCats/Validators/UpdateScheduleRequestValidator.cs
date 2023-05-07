using Application.Contracts.Request;
using FluentValidation;

namespace CliVetDogsCats.API.Validators
{
    public class UpdateScheduleRequestValidator : AbstractValidator<UpdateScheduleRequest>
    {
        public UpdateScheduleRequestValidator()
        {
            RuleFor(model => model.Id).Must(ValidateGuid.BeAValidGuid)
                .WithMessage("O Id do schedule é obrigatório");
            
            RuleFor(model => model.ScheduleDate).NotEmpty()
                .WithMessage("A data do agendamento é obrigatório");

            RuleFor(model => model.Hour).NotEmpty()
                .WithMessage("A hora do agendamento é obrigatório");

            RuleFor(model => model.ScheduleStatusId).NotEmpty()
                .WithMessage("É obrigatório selecionar um status para o agendamento");

            RuleFor(model => model.EmployeeId).NotEmpty()
                .WithMessage("É obrigatório selecionar um veterinário");            

        }
    }
}
