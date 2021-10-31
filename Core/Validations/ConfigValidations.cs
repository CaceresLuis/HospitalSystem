using Core.Dtos;
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
    
    public class NurseValidation : AbstractValidator<NurseDto>
    {
        public NurseValidation()
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
    
    public class DoctorValidation : AbstractValidator<DoctorDto>
    {
        public DoctorValidation()
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
    
    public class QuoteValidation : AbstractValidator<QuoteDto>
    {
        public QuoteValidation()
        {
            RuleFor(p => p.Doctor)
                .NotNull()
                .WithMessage("The doctor is requiered");
            RuleFor(p => p.Nurse)
                .NotEmpty()
                .WithMessage("The nurse is requiered");
            RuleFor(p => p.MedicalHistory)
                .NotEmpty()
                .WithMessage("The medical history is requiered");
        }
    }
}
