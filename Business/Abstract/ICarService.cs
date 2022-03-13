using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();

        void Add(Car car);

        List<Car> GetCarsByBrandId(int brandId);

        List<Car> GetCarsByColorId(int colorId);

        
    }
}
