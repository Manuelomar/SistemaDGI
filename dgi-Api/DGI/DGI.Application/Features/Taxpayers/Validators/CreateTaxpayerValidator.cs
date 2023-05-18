using DGI.Application.Features.Taxpayers.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGI.Application.Features.Taxpayers.Validators
{
    public class CreateTaxpayerValidator : AbstractValidator<CreateTaxpayerRequest>
    {
        public CreateTaxpayerValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
            .WithMessage("El nombre no puede estar vacio");
            RuleFor(x => x.Status).IsInEnum()
          .WithMessage("El status no puede estar vacio");
            RuleFor(x => x.RncCedula)
          .NotEmpty().WithMessage("La cédula no puede estar vacía")
          .Length(11).WithMessage("La cédula debe tener exactamente 11 caracteres")
          .Must(x => x.All(char.IsDigit)).WithMessage("La cédula solo puede contener dígitos numéricos");
            RuleFor(x => x.Type).NotEmpty()
            .WithMessage("El tipo no puede estar vacio");

        }
    }
}
