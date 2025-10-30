using Entities.Concrete;
using Entities.DTOs.CarDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CreateCarValidator:AbstractValidator<CreateCarDTO>
    {
        public CreateCarValidator()
        {
            RuleFor(x => x.BrandId)
            .NotEmpty().WithMessage("Brand is required.");

            RuleFor(x => x.ColorId)
                .NotEmpty().WithMessage("Color is required.");

            RuleFor(x => x.ModelYear)
                .InclusiveBetween((short)1990, (short)DateTime.Now.Year)
                .WithMessage("Year must be between 1990 and the current year.");

            RuleFor(x => x.DailyPrice)
                .GreaterThan(0)
                .WithMessage("Price must be greater than zero.");
        }
    }
}
