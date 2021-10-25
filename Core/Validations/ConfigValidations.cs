﻿using Core.Dtos;
using FluentValidation;

namespace Core.Validations
{
    public class ConfigValidations{}

    public class PatientValidation : AbstractValidator<PatientsDto>
    {
        public PatientValidation()
        {
            RuleFor(p => p.FullName)
                .NotEmpty()
                .WithMessage("The FullName is requiered");
            RuleFor(p => p.Document)
                .NotEmpty()
                .WithMessage("The Document is requiered");
            RuleFor(p => p.Adresss)
                .NotEmpty()
                .WithMessage("The Adresss is requiered");
            RuleFor(p => p.Phone)
                .NotEmpty()
                .WithMessage("The Phone is requiered");
        }
    }
}
