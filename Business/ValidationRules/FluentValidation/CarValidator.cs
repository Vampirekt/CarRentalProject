using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<CarDetailDTO>
    {
        public CarValidator()
        {
            RuleFor(x => x.BrandId)
            .NotEmpty().WithMessage("Brand is required.");

            RuleFor(x => x.Model)
                .NotEmpty().WithMessage("Model is required.");

            RuleFor(x => x.Year)
                .InclusiveBetween(1990, DateTime.Now.Year)
                .WithMessage("Year must be between 1990 and the current year.");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than zero.");
        }
    }
}
