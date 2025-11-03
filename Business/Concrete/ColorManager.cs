using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.ColorDTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class ColorManager : IColorService

    {
        private readonly IColorDal _ColorDal;

        

        public ColorManager(IColorDal ColorDal)

        {
            
            _ColorDal = ColorDal;
        }

        public IDataResult<ColorDetailDTO> Add(CreateColorDTO color)
        {
           
            Color color1 = new Color
            {
                Name = color.Name
            };
            _ColorDal.Add(color1);
            return new SuccessDataResult<ColorDetailDTO>();

        }

        public IResult Delete(Color color)
        {
            _ColorDal.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<Color> Get(Expression<Func<Color, bool>> predicate)
        {
            return new SuccessDataResult<Color>(_ColorDal.Get(predicate));
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_ColorDal.GetAll());
        }

        public IResult Update(Color color)
        {
            _ColorDal.Update(color);
            return new SuccessResult();
        }

    }
}
