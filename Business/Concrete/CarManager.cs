using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

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

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));


        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));

        }
    }
}
