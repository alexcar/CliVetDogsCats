using FluentValidation;
using Application.Contracts.Request;

namespace CliVetDogsCats.API.Validators
{
    public class CreateAnimalRequestValidator : AbstractValidator<CreateAnimalRequest>
    {
        public CreateAnimalRequestValidator()
        {
            RuleFor(model => model.Name).NotEmpty().WithMessage("O nome do animal obrigatório");
            RuleFor(model => model.Coat).NotEmpty().WithMessage("O tipo de pelagem do animal obrigatório");
            
            RuleFor(model => model.Sexo).NotEmpty().WithMessage("O sexo do animal obrigatório")
                .Must(x => x.Length == 1).WithMessage("Informe M ou F para o sexo");

            RuleFor(model => model.BirthDate).NotEmpty().WithMessage("A data de nascimento do animal obrigatório");
            RuleFor(model => model.Weigth).NotEmpty().WithMessage("O peso do animal obrigatório");
            RuleFor(model => model.TutorId).Must(ValidateGuid.BeAValidGuid)
                .WithMessage("É obrigatório selecionar o tutor do animal");
            RuleFor(model => model.SpeciesId).Must(ValidateGuid.BeAValidGuid)
                .WithMessage("É obrigatório selecionar a espécie do animal");
            RuleFor(model => model.RaceId).Must(ValidateGuid.BeAValidGuid)
                .WithMessage("É obrigatório selecionar a raça do animal");
            RuleFor(model => model.AnimalSizeId).Must(ValidateGuid.BeAValidGuid)
                .WithMessage("É obrigatório selecionar o porte do animal");
        }
    }
}
