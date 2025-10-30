using Core.Utilities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity) { 
            var context = new ValidationContext<object>(entity);
            var validatorResult = validator.Validate(context);
            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }


        }
    }
}

