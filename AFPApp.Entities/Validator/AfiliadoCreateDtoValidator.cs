using AFPApp.Entities.Dto;
using FluentValidation;

namespace AFPApp.Entities.Validator {
    public class AfiliadoCreateDtoValidator : AbstractValidator<AfiliadoCreateDto> {
        private const string REQMESSAGE = "El campo es requerido";

        public AfiliadoCreateDtoValidator() {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage(REQMESSAGE)
                .MaximumLength(100).WithMessage("La longitud máxima permitad es {MaxLength} caracteres");
            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage(REQMESSAGE)
                .MaximumLength(100).WithMessage("La longitud máxima permitad es {MaxLength} caracteres");
            RuleFor(x => x.Edad)
                .NotEmpty().WithMessage(REQMESSAGE)
                .InclusiveBetween(18, 35).WithMessage("La edad debe estar entre {From} a {To} años");
        }
    }
}
