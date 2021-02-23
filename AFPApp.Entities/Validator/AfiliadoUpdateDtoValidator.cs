using AFPApp.Entities.Dto;
using FluentValidation;

namespace AFPApp.Entities.Validator {
    public class AfiliadoUpdateDtoValidator : AbstractValidator<AfiliadoUpdateDto> {
        private const string REQMESSAGE = "El campo es requerido";

        public AfiliadoUpdateDtoValidator() {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage(REQMESSAGE)
                .MaximumLength(100).WithMessage("La longitud máxima permitad es {MaxLength} caracteres");
            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage(REQMESSAGE)
                .MaximumLength(100).WithMessage("La longitud máxima permitad es {MaxLength} caracteres");
            RuleFor(x => x.Edad)
                .NotEmpty().WithMessage(REQMESSAGE)
                .InclusiveBetween(18, 60).WithMessage("La edad debe estar entre {From} a {To} años");
            RuleFor(x => x.Bio)
                .MaximumLength(500).WithMessage("La cantidad máxima de caracteres permitidos es {MaxLength}");
        }
    }
}
