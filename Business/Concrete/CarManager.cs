using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using Color = Entities.Concrete.Color;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly IBrandService _brandService;
        private readonly IColorService _colorService;


        public CarManager(ICarDal carDal, IColorService colorService, IBrandService brandService)
        {
            _carDal = carDal;
            _colorService = colorService;
            _brandService = brandService;
        }

        public IDataResult<CarDetailDTO> Add(CreateCarDTO car)
        {
            if (car.Description.Length <= 2
                || car.DailyPrice <= 0)
            {

                return new ErrorDataResult<CarDetailDTO>("Mininmum description length is 2 & minimum car price" +
                  "is 1");
            }
            Color color = _colorService.Get(p => p.Id == car.ColorId).Data;
            if (color == null) return new ErrorDataResult<CarDetailDTO>("Color not found");
            Brand brand = _brandService.Get(p => p.Id == car.BrandId).Data;
            if (brand == null) return new ErrorDataResult<CarDetailDTO>("Brand not found");

            Car carEntity = new Car
            {
                ColorId = car.ColorId,
                BrandId = car.BrandId,
                DailyPrice = car.DailyPrice,
                Description = car.Description,
                ModelYear = car.ModelYear
            };
            _carDal.Add(carEntity);
            CarDetailDTO carDetailDTO = new CarDetailDTO { BrandName = brand.Name, CarId = carEntity.Id, ColorName = color.Name, DailyPrice = carEntity.DailyPrice };
            return new SuccessDataResult<CarDetailDTO>(carDetailDTO, Messages.CarAdded);

        }

        public IResult Delete(int id)
        {
            var car = _carDal.Get(c => c.Id == id);
            if (car == null)
                return new ErrorResult("Car not found");

            _carDal.Delete(car);

            
            return new SuccessResult("Car deleted successfully");
        }

        public IDataResult<CarDetailDTO> Get(Expression<Func<Car, bool>> predicate)
        {
            var carEntity = _carDal.Get(predicate);
            if (carEntity == null)
                return new ErrorDataResult<CarDetailDTO>("Car not found");

            var color = _colorService.Get(c => c.Id == carEntity.ColorId).Data;
            if (color == null)
                return new ErrorDataResult<CarDetailDTO>("Color not found");

            var brand = _brandService.Get(b => b.Id == carEntity.BrandId).Data;
            if (brand == null)
                return new ErrorDataResult<CarDetailDTO>("Brand not found");

            var carDetailDTO = new CarDetailDTO
            {
                CarId = carEntity.Id,
                BrandName = brand.Name,
                ColorName = color.Name,
                DailyPrice = carEntity.DailyPrice,
            };

            return new SuccessDataResult<CarDetailDTO>(carDetailDTO, "Car retrieved successfully");
        }


        public IDataResult<List<CarDetailDTO>> GetAll(Expression<Func<Car, bool>> predicate = null)
        {
            var carEntities = _carDal.GetAll(predicate);
            if (carEntities == null || !carEntities.Any())
                return new ErrorDataResult<List<CarDetailDTO>>("No cars found");

            var carDetailList = new List<CarDetailDTO>();

            foreach (var car in carEntities)
            {
                var color = _colorService.Get(c => c.Id == car.ColorId).Data;
                var brand = _brandService.Get(b => b.Id == car.BrandId).Data;

                if (color == null || brand == null)
                    continue;

                carDetailList.Add(new CarDetailDTO
                {
                    CarId = car.Id,
                    BrandName = brand.Name,
                    ColorName = color.Name,
                    DailyPrice = car.DailyPrice
                });
            }

            if (!carDetailList.Any())
                return new ErrorDataResult<List<CarDetailDTO>>("No car details could be retrieved");

            return new SuccessDataResult<List<CarDetailDTO>>(carDetailList, "Cars retrieved successfully");
        }


        public IDataResult<CarDetailDTO> Update(int id, UpdateCarDTO carDto)
        {
            throw new NotImplementedException();
        }
    }
}
