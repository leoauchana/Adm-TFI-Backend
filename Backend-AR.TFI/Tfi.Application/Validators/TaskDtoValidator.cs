using FluentValidation;
using Tfi.Application.DTOs;

namespace Tfi.Application.Validators;

public class TaskDtoValidator : AbstractValidator<TaskDto.Request>
{
    public TaskDtoValidator()
    {
        RuleFor(t => t.taskDescription)
            .NotEmpty().WithMessage("La {PropertyName} de la tarea no puede estar vacía.")
            .MaximumLength(150).WithMessage("La {PropertyName} debe tener como maximo 150 caracteres.")
            .MinimumLength(20).WithMessage("La {PropertyName} debe tener como mínimo 20 caracteres.");
        RuleFor(t => t.taskName)
            .NotEmpty().WithMessage("El {PropertyName} no puede estar vacío.")
            .MaximumLength(25).WithMessage("El {PropertyName} debe tener como maximo de 25 caracteres.")
            .MinimumLength(7).WithMessage("El {PropertyName} debe tener como mínimo 7 caracteres.");
        //RuleFor(c => c.dni)
        //    .NotEmpty().WithMessage("El {PropertyName} del cliente no puede estar vacío.")
        //    .Must(d => d.ToString().Length == 7 || d.ToString().Length == 8).WithMessage("El {PropertyName} debe tener exactamente 7 o 8 caracteres.");
        //RuleFor(c => c.age)
        //    .NotEmpty().WithMessage("La {PropertyName} del cliente no puede estar vacía.")
        //    .InclusiveBetween(18, 65).WithMessage("La {PropertyName} debe estar entre 18 y 65 años.");
        //RuleFor(c => c.domicile)
        //    .NotEmpty().WithMessage("El {PropertyName} del cliente no puede estar vacío.")
        //    .MaximumLength(50).WithMessage("El {PropertyName} debe tener como maximo de 50 caracteres.")
        //    .MinimumLength(10).WithMessage("El {PropertyName} debe tener al menos 10 caracteres.");
    }
}
