using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }

            Car car = new Car
            {
                BrandId=1,
                ColorId=1,
                DailyPrice=250,
                Description="A",
                ModelYear=1800
            };

            carManager.Add(car);
            Console.WriteLine("veri eklendi");
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }
        }
    }

}
