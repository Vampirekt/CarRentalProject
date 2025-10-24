using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarDal
    {
        List<Car> _car;
        public InMemoryProductDal()
        {
            _car = new List<Car>
            {
                new Car{Id=1,BrandId=2,ColorId=3,DailyPrice=100,Description="Sedan",ModelYear=2002
              }
            };
        }





        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            var CarToDelete = _car.SingleOrDefault(c => c.Id == car.Id);
            _car.Remove(CarToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDTO> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var CarToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);
            CarToUpdate.Id = car.Id;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.Description = car.Description;
            CarToUpdate.ModelYear = car.ModelYear;
        }
    }
}
