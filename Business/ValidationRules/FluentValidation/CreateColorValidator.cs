using Entities.DTOs.CarDTOs;
using Entities.DTOs.ColorDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CreateColorValidator: AbstractValidator<CreateColorDTO>
    {
        public CreateColorValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
