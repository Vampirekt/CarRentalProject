using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserService

    {
        IResult Add(User user);
        IDataResult<List<Brand>> GetAll();
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
    }
}
