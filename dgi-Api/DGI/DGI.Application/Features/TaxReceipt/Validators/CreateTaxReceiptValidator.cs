using DGI.Application.Features.TaxReceipt.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGI.Application.Features.TaxReceipt.Validators
{
    public class CreateTaxReceiptValidator : AbstractValidator<CreateTaxReceiptRequest>
    {
        public CreateTaxReceiptValidator()
        {
            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("El monto no puede estar vacío")
                .Must(x => decimal.TryParse(x.ToString(), out _)).WithMessage("El monto debe ser numérico");


            RuleFor(x => x.IdentificationNumber).NotEmpty()
           .WithMessage("El nombre no puede estar vacio")
            .NotEmpty().WithMessage("La cédula no puede estar vacía")
         .Length(11).WithMessage("La cédula debe tener exactamente 11 caracteres")
        .Must(x => x.All(char.IsDigit)).WithMessage("La cédula solo puede contener dígitos numéricos");
            RuleFor(x => x.NCF).NotEmpty();

        }
    }
}
