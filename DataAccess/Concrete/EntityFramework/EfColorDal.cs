using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarDTOs;
using Entities.DTOs.ColorDTOs;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, CarRentalContext>, IColorDal

    {
        public List<ColorDetailDTO> GetColorDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from co in context.Colors
                             join c in context.Cars on co.Id equals c.ColorId
                             select new ColorDetailDTO()
                             {
                                 Name = co.Name


                             };
                return result.ToList();





            }

        }
    }
}
