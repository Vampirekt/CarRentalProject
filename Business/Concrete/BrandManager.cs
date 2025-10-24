using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _BrandDal;
        public BrandManager(IBrandDal BrandDal)
        {
            _BrandDal = BrandDal;
        }
        public IResult Add(Brand brand)
        {
            _BrandDal.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            _BrandDal.Delete(brand);
            return new SuccessResult();

        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_BrandDal.GetAll());
        }

        public IResult Update(Brand brand)
        {
            _BrandDal.Update(brand);
            return new SuccessResult();
        }
        public IDataResult<Brand> Get(Expression<Func<Brand, bool>> predicate)
        {
            return new SuccessDataResult<Brand>(_BrandDal.Get(predicate));
        }
    }
}
