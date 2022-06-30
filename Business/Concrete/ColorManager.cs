using Business.Abstract;
using DataAccess.Abstract;
using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService

    {
        IColorDal _ColorDal;

        public ColorManager(IColorDal ColorDal)
            
        {
            _ColorDal = ColorDal;
        }

        public IResult Add(Color color)
        {
            if (color.Name.Length <= 2)
            {
                return new ErrorResult();
            }
            else _ColorDal.Add(color);
            return new SuccessResult();
            
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_ColorDal.GetAll(),true);
        }
    }
}
