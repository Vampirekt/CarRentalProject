
using Core.Utilities.Results;
using Entities.Concrete;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Brand brand);
        IDataResult<List<Brand>> GetAll();
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
    }
}
