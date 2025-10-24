using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> Get(Expression<Func<Color, bool>> predicate);

        IResult Delete(Color color);
        IResult Update(Color color);
    }
}
