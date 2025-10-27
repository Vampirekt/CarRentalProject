using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface ICarService
    {

        IDataResult<CarDetailDTO> Add(CreateCarDTO carDto);
        IDataResult<CarDetailDTO> Update(int id, UpdateCarDTO carDto);
        IResult Delete(int id);

        IDataResult<List<CarDetailDTO>> GetAll(Expression<Func<Car, bool>> predicate = null);
        IDataResult<CarDetailDTO> Get(Expression<Func<Car, bool>> predicate);
    }

}
}
